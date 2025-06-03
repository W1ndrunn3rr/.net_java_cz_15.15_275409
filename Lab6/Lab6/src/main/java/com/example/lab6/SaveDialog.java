package com.example.lab6;

import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.image.PixelReader;
import javafx.scene.layout.*;
import javafx.stage.Modality;
import javafx.stage.Stage;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;


public class SaveDialog {
    public static void show(Image imageToSave, boolean operationsPerformed) {
        Stage modalStage = new Stage();
        modalStage.initModality(Modality.APPLICATION_MODAL);
        modalStage.setTitle("Zapisz obraz");
        modalStage.setResizable(false);

        VBox modalContent = new VBox(15);
        modalContent.setPadding(new Insets(20));
        modalContent.setAlignment(Pos.CENTER);

        if (!operationsPerformed) {
            Label warningLabel = new Label("Na pliku nie zostały wykonane żadne operacje!");
            warningLabel.setStyle("-fx-text-fill: orange; -fx-font-weight: bold;");
            modalContent.getChildren().add(warningLabel);
        }

        Label nameLabel = new Label("Nazwa pliku:");
        TextField nameField = new TextField();
        nameField.setPromptText("Wpisz nazwę pliku (3-100 znaków)");
        nameField.setPrefWidth(300);

        nameField.textProperty().addListener((obs, oldText, newText) -> {
            if (newText.length() > 100) {
                nameField.setText(oldText);
            }
        });

        Label errorLabel = new Label();
        errorLabel.setStyle("-fx-text-fill: red;");

        HBox buttonBox = new HBox(10);
        buttonBox.setAlignment(Pos.CENTER);

        Button saveBtn = new Button("Zapisz");
        Button cancelBtn = new Button("Anuluj");

        saveBtn.setOnAction(e -> {
            String fileName = nameField.getText().trim();

            if (fileName.length() < 3) {
                errorLabel.setText("Wpisz co najmniej 3 znaki");
                return;
            }

            try {
                String userHome = System.getProperty("user.home");
                Path picturesPath = Paths.get(userHome, "Pictures");

                if (!Files.exists(picturesPath)) {
                    Files.createDirectories(picturesPath);
                }

                Path targetPath = picturesPath.resolve(fileName + ".jpg");

                if (Files.exists(targetPath)) {
                    Alert alert = new Alert(Alert.AlertType.CONFIRMATION);
                    alert.setTitle("Potwierdzenie");
                    alert.setHeaderText("Plik już istnieje");
                    alert.setContentText("Czy chcesz zastąpić istniejący plik?");

                    if (alert.showAndWait().get() != ButtonType.OK) {
                        return;
                    }
                }

                ImageProcessor.saveImage(imageToSave, targetPath);
                Toast.show("Obraz został zapisany w: " + targetPath, "success");
                modalStage.close();
            } catch (Exception ex) {
                Toast.show("Nie udało się zapisać pliku", "error");
            }
        });

        cancelBtn.setOnAction(e -> modalStage.close());
        buttonBox.getChildren().addAll(saveBtn, cancelBtn);
        modalContent.getChildren().addAll(nameLabel, nameField, errorLabel, buttonBox);

        Scene modalScene = new Scene(modalContent, 400, operationsPerformed ? 200 : 250);
        modalStage.setScene(modalScene);
        modalStage.showAndWait();
    }
}