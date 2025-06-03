package com.example.lab6;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.*;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.File;
import java.io.FileInputStream;
import java.util.logging.Logger;

public class MainView extends Application {

    private ImageView originalImageView;
    private ImageView processedImageView;
    private ComboBox<String> operationsComboBox;
    private Button executeButton;
    private Button saveButton;
    private Button scaleButton;
    private Button rotateLeftButton;
    private Button rotateRightButton;
    private File currentImageFile;
    private Image currentOriginalImage;
    private Image currentProcessedImage;
    private boolean operationsPerformed = false;

    private FileLogger fileLogger = new FileLogger();

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Przetwarzanie obrazów 4");

        BorderPane root = new BorderPane();
        root.setPadding(new Insets(10));

        VBox header = createHeader();
        root.setTop(header);

        VBox center = createCenterContent();
        root.setCenter(center);

        Label footer = new Label("© 2025 Jakub Gilewicz 275409 - Politechnika Wrocławska, W12N");
        footer.setStyle("-fx-font-size: 10px; -fx-text-fill: gray;");
        BorderPane.setAlignment(footer, Pos.CENTER);
        root.setBottom(footer);

        Scene scene = new Scene(root, 800, 800);

        primaryStage.setScene(scene);
        root.setStyle("-fx-background-color: white;");
        primaryStage.show();
    }

    private VBox createHeader() {
        VBox header = new VBox(10);
        header.setAlignment(Pos.CENTER);
        header.setPadding(new Insets(0, 0, 20, 0));

        ImageView logoView = new ImageView();
        try {
            logoView.setFitWidth(300);
            logoView.setFitHeight(150);
            logoView.setStyle("-fx-background-color: #0066cc; -fx-background-radius: 5;");
            logoView.setImage(new Image(new FileInputStream("D:\\.net_java_cz_15.15_275409\\Lab6\\Lab6\\src\\images\\Logotyp-PWr.jpg")));
        } catch (Exception e) {
            System.out.println("Nie można wczytać logo");
        }

        header.getChildren().addAll(logoView);
        return header;
    }

    private VBox createCenterContent() {
        VBox center = new VBox(20);
        center.setAlignment(Pos.TOP_CENTER);

        Label welcomeLabel = new Label("Witaj w programie 'Przetwarzanie obrazów 4'");
        welcomeLabel.setStyle("-fx-font-size: 18px; -fx-font-weight: bold;");

        VBox controlPanel = createControlPanel();
        HBox imagePanel = createImagePanel();

        center.getChildren().addAll(welcomeLabel, controlPanel, imagePanel);
        return center;
    }

    private VBox createControlPanel() {
        VBox mainControlPanel = new VBox(15);
        mainControlPanel.setAlignment(Pos.CENTER);
        mainControlPanel.setPadding(new Insets(20));
        mainControlPanel.setStyle("-fx-background-color: white; -fx-background-radius: 10;");

        HBox firstLine = new HBox(15);
        firstLine.setAlignment(Pos.CENTER);

        Button loadButton = new Button("Wczytaj obraz");
        loadButton.setOnAction(e -> loadImage());
        loadButton.setStyle("-fx-font-size: 14px; -fx-padding: 10;");

        operationsComboBox = new ComboBox<>();
        operationsComboBox.getItems().addAll(
                "Negatyw",
                "Progowanie",
                "Konturowanie"
        );
        operationsComboBox.setPromptText("Wybierz operację...");
        operationsComboBox.setPrefWidth(200);
        operationsComboBox.setDisable(true);

        executeButton = new Button("Wykonaj");
        executeButton.setOnAction(e -> {
            executeOperation();
            fileLogger.Log("Wykonano operację : " + operationsComboBox.getValue(), 1);
        }
        );
        executeButton.setDisable(true);
        executeButton.setStyle("-fx-font-size: 14px; -fx-padding: 10;");

        firstLine.getChildren().addAll(loadButton, operationsComboBox, executeButton);

        HBox secondLine = new HBox(15);
        secondLine.setAlignment(Pos.CENTER);

        rotateLeftButton = new Button("Obrót w lewo");
        rotateLeftButton.setOnAction(e -> {
            fileLogger.Log("Wykonano operację obrotu w lewo o 90 stopni", 1);
            rotateImage(-90);
        });
        rotateLeftButton.setDisable(true);
        rotateLeftButton.setStyle("-fx-font-size: 14px; -fx-padding: 10;");

        rotateRightButton = new Button("Obrót w prawo");
        rotateRightButton.setOnAction(e ->
        {
            fileLogger.Log("Wykonano operację obrotu w prawo o 90 stopni", 1);
            rotateImage(90);
        });
        rotateRightButton.setDisable(true);
        rotateRightButton.setStyle("-fx-font-size: 14px; -fx-padding: 10;");

        scaleButton = new Button("Skaluj obraz");
        scaleButton.setOnAction(e -> {
            fileLogger.Log("Wykonano operację skalowania", 1);
            ScaleDialog.show(this::scaleImage);
        });
        scaleButton.setDisable(true);
        scaleButton.setStyle("-fx-font-size: 14px; -fx-padding: 10;");

        saveButton = new Button("Zapisz obraz");
        saveButton.setOnAction(e -> saveImage());
        saveButton.setDisable(true);
        saveButton.setStyle("-fx-font-size: 14px; -fx-padding: 10;");

        secondLine.getChildren().addAll(rotateLeftButton, rotateRightButton, scaleButton, saveButton);

        mainControlPanel.getChildren().addAll(firstLine, secondLine);
        return mainControlPanel;
    }

    private HBox createImagePanel() {
        HBox imagePanel = new HBox(20);
        imagePanel.setAlignment(Pos.CENTER);

        VBox originalPanel = new VBox(10);
        originalPanel.setAlignment(Pos.CENTER);
        Label originalLabel = new Label("Obraz oryginalny");
        originalLabel.setStyle("-fx-font-size: 14px; -fx-font-weight: bold;");

        originalImageView = new ImageView();
        originalImageView.setFitWidth(350);
        originalImageView.setFitHeight(250);
        originalImageView.setPreserveRatio(true);
        originalImageView.setStyle("-fx-background-color: #eeeeee; -fx-border-color: #cccccc; -fx-border-width: 2;");

        originalPanel.getChildren().addAll(originalLabel, originalImageView);

        VBox processedPanel = new VBox(10);
        processedPanel.setAlignment(Pos.CENTER);
        Label processedLabel = new Label("Obraz po obróbce");
        processedLabel.setStyle("-fx-font-size: 14px; -fx-font-weight: bold;");

        processedImageView = new ImageView();
        processedImageView.setFitWidth(350);
        processedImageView.setFitHeight(250);
        processedImageView.setPreserveRatio(true);
        processedImageView.setStyle("-fx-background-color: #eeeeee; -fx-border-color: #cccccc; -fx-border-width: 2;");

        processedPanel.getChildren().addAll(processedLabel, processedImageView);

        imagePanel.getChildren().addAll(originalPanel, processedPanel);
        return imagePanel;
    }

    private void loadImage() {
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle("Wybierz plik obrazu");
        fileChooser.getExtensionFilters().add(
                new FileChooser.ExtensionFilter("Pliki JPG (*.jpg)", "*.jpg")
        );

        File selectedFile = fileChooser.showOpenDialog(null);

        if (selectedFile != null && selectedFile.getName().toLowerCase().endsWith(".jpg")) {
            try {
                currentImageFile = selectedFile;
                currentOriginalImage = new Image(selectedFile.toURI().toString());
                originalImageView.setImage(currentOriginalImage);
                processedImageView.setImage(null);
                currentProcessedImage = null;
                operationsPerformed = false;

                operationsComboBox.setDisable(false);
                executeButton.setDisable(false);
                saveButton.setDisable(false);
                scaleButton.setDisable(false);
                rotateLeftButton.setDisable(false);
                rotateRightButton.setDisable(false);

                Toast.show("Pomyślnie załadowano plik", "success");
                fileLogger.Log("Użytkownik załadował plik", 1);
            } catch (Exception e) {
                Toast.show("Nie udało się załadować pliku", "error");
            }
        } else if (selectedFile != null) {
            fileLogger.Log("Nieodpowiedni format pliku", 2);
            Toast.show("Niedozwolony format pliku", "error");
        }
    }

    private void executeOperation() {
        String selectedOperation = operationsComboBox.getValue();

        if (selectedOperation == null) {
            fileLogger.Log("Nie wybrano operacji do wykonania", 2);
            Toast.show("Nie wybrano operacji do wykonania", "warning");
            return;
        }

        if (currentOriginalImage == null) {
            fileLogger.Log("Bład wczytania obrazu", 2);
            Toast.show("Nie wczytano obrazu", "error");
            return;
        }

        try {
            Image workingImage = getWorkingImage();

            switch (selectedOperation) {
                case "Progowanie":
                    ThresholdDialog.show(this::applyThreshold);
                    break;
                case "Negatyw":
                    currentProcessedImage = ImageProcessor.createNegative(workingImage);
                    processedImageView.setImage(currentProcessedImage);
                    operationsPerformed = true;
                    Toast.show("Negatyw został wygenerowany pomyślnie!", "success");
                    break;
                case "Konturowanie":
                    currentProcessedImage = ImageProcessor.createContours(workingImage);
                    processedImageView.setImage(currentProcessedImage);
                    operationsPerformed = true;
                    Toast.show("Konturowanie zostało przeprowadzone pomyślnie!", "success");
                    break;
                default:
                    fileLogger.Log("Nieznana operacja", 2);
                    Toast.show("Nieznana operacja", "error");
                    break;
            }
        } catch (Exception e) {
            fileLogger.Log("Bład wykonania operacji", 2);
            Toast.show("Nie udało się wykonać operacji", "error");
        }
    }

    private Image getWorkingImage() {
        return currentProcessedImage != null ? currentProcessedImage : currentOriginalImage;
    }

    private void rotateImage(int degrees) {
        if (currentOriginalImage == null) {
            fileLogger.Log("Bład wczytywania obrazu", 2);
            Toast.show("Nie wczytano obrazu", "error");
            return;
        }

        try {
            currentProcessedImage = ImageProcessor.rotateImageByDegrees(getWorkingImage(), degrees);
            processedImageView.setImage(currentProcessedImage);
            operationsPerformed = true;

            String direction = degrees > 0 ? "w prawo" : "w lewo";
            Toast.show("Obrót " + direction + " został wykonany", "success");
        } catch (Exception e) {
            fileLogger.Log("Bład wykonania operacji obrotu", 2);
            Toast.show("Nie udało się wykonać obrotu", "error");
        }
    }

    private void scaleImage(int width, int height) {
        try {
            currentProcessedImage = ImageProcessor.scaleImage(getWorkingImage(), width, height);
            processedImageView.setImage(currentProcessedImage);
            operationsPerformed = true;
            Toast.show("Skalowanie zostało wykonane", "success");
        } catch (Exception e) {
            fileLogger.Log("Bład wykonania operacji skalowania", 2);
            Toast.show("Nie udało się przeskalować obrazu", "error");
        }
    }

    private void applyThreshold(int threshold) {
        try {
            currentProcessedImage = ImageProcessor.createThreshold(getWorkingImage(), threshold);
            processedImageView.setImage(currentProcessedImage);
            operationsPerformed = true;
            Toast.show("Progowanie zostało przeprowadzone pomyślnie!", "success");
        } catch (Exception e) {
            fileLogger.Log("Bład wykonania operacji progowania", 2);
            Toast.show("Nie udało się wykonać progowania.", "error");
        }
    }

    private void saveImage() {
        if (currentOriginalImage == null) {
            fileLogger.Log("Bład zapisu obrazu", 2);
            Toast.show("Nie wczytano obrazu", "error");
            return;
        }
        fileLogger.Log("Zapisano obraz do pliku", 1);
        SaveDialog.show(currentProcessedImage != null ? currentProcessedImage : currentOriginalImage, operationsPerformed);
    }

    public static void main(String[] args) {
        FileLogger fileLogger = new FileLogger();
        fileLogger.Log("Aplikacja została uruchomiona", 1);
        launch(args);
        fileLogger.Log("Aplikacja została zamknięta", 1);
    }
}
