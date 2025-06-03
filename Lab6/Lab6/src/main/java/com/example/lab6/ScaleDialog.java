package com.example.lab6;

import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class ScaleDialog {

    public interface ScaleCallback {
        void scale(int width, int height);
    }

    public static void show(ScaleCallback callback) {
        Stage modalStage = new Stage();
        modalStage.initModality(Modality.APPLICATION_MODAL);
        modalStage.setTitle("Skalowanie obrazu");
        modalStage.setResizable(false);

        VBox modalContent = new VBox(15);
        modalContent.setPadding(new Insets(20));
        modalContent.setAlignment(Pos.CENTER);

        Label titleLabel = new Label("Zmień rozmiar obrazu");
        titleLabel.setStyle("-fx-font-size: 16px; -fx-font-weight: bold;");

        HBox dimensionsBox = new HBox(15);
        dimensionsBox.setAlignment(Pos.CENTER);

        VBox widthBox = new VBox(5);
        Label widthLabel = new Label("Szerokość (px):");
        TextField widthField = new TextField();
        widthField.setPromptText("0-3000");
        Label widthError = new Label();
        widthError.setStyle("-fx-text-fill: red; -fx-font-size: 10px;");
        widthBox.getChildren().addAll(widthLabel, widthField, widthError);

        VBox heightBox = new VBox(5);
        Label heightLabel = new Label("Wysokość (px):");
        TextField heightField = new TextField();
        heightField.setPromptText("0-3000");
        Label heightError = new Label();
        heightError.setStyle("-fx-text-fill: red; -fx-font-size: 10px;");
        heightBox.getChildren().addAll(heightLabel, heightField, heightError);

        addNumericValidation(widthField, 3000);
        addNumericValidation(heightField, 3000);

        dimensionsBox.getChildren().addAll(widthBox, heightBox);

        HBox buttonBox = new HBox(10);
        buttonBox.setAlignment(Pos.CENTER);

        Button scaleBtn = new Button("Zmień rozmiar");
        Button cancelBtn = new Button("Anuluj");

        scaleBtn.setOnAction(e -> {
            widthError.setText("");
            heightError.setText("");

            boolean valid = true;

            if (widthField.getText().trim().isEmpty()) {
                widthError.setText("Pole jest wymagane");
                valid = false;
            }

            if (heightField.getText().trim().isEmpty()) {
                heightError.setText("Pole jest wymagane");
                valid = false;
            }

            if (valid) {
                try {
                    int width = Integer.parseInt(widthField.getText().trim());
                    int height = Integer.parseInt(heightField.getText().trim());

                    if (width <= 0 || width > 3000 || height <= 0 || height > 3000) {
                        Toast.show("Wymiary muszą być w zakresie 1-3000", "error");
                        return;
                    }

                    callback.scale(width, height);
                    modalStage.close();
                } catch (NumberFormatException ex) {
                    Toast.show("Wprowadź prawidłowe liczby", "error");
                }
            }
        });

        cancelBtn.setOnAction(e -> modalStage.close());
        buttonBox.getChildren().addAll(scaleBtn, cancelBtn);
        modalContent.getChildren().addAll(titleLabel, dimensionsBox, buttonBox);

        Scene modalScene = new Scene(modalContent, 400, 200);
        modalStage.setScene(modalScene);
        modalStage.showAndWait();
    }

    private static void addNumericValidation(TextField field, int max) {
        field.textProperty().addListener((obs, oldText, newText) -> {
            if (!newText.matches("\\d*")) {
                field.setText(newText.replaceAll("[^\\d]", ""));
            }
            if (!field.getText().isEmpty()) {
                try {
                    int value = Integer.parseInt(field.getText());
                    if (value > max) {
                        field.setText(String.valueOf(max));
                    }
                } catch (NumberFormatException e) {
                    field.setText(oldText);
                }
            }
        });
    }
}