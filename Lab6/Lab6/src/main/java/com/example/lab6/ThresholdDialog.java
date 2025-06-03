package com.example.lab6;

import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class ThresholdDialog {

    public interface ThresholdCallback {
        void applyThreshold(int threshold);
    }

    public static void show(ThresholdCallback callback) {
        Stage modalStage = new Stage();
        modalStage.initModality(Modality.APPLICATION_MODAL);
        modalStage.setTitle("Progowanie obrazu");
        modalStage.setResizable(false);

        VBox modalContent = new VBox(15);
        modalContent.setPadding(new Insets(20));
        modalContent.setAlignment(Pos.CENTER);

        Label titleLabel = new Label("Ustaw próg progowania");
        titleLabel.setStyle("-fx-font-size: 16px; -fx-font-weight: bold;");

        Label thresholdLabel = new Label("Wartość progu (0-255):");
        TextField thresholdField = new TextField();
        thresholdField.setPromptText("0-255");
        addNumericValidation(thresholdField, 255);

        HBox buttonBox = new HBox(10);
        buttonBox.setAlignment(Pos.CENTER);

        Button thresholdBtn = new Button("Wykonaj progowanie");
        Button cancelBtn = new Button("Anuluj");

        thresholdBtn.setOnAction(e -> {
            try {
                if (thresholdField.getText().trim().isEmpty()) {
                    Toast.show("Wprowadź wartość progu", "warning");
                    return;
                }

                int threshold = Integer.parseInt(thresholdField.getText().trim());

                if (threshold < 0 || threshold > 255) {
                    Toast.show("Próg musi być w zakresie 0-255", "error");
                    return;
                }

                callback.applyThreshold(threshold);
                modalStage.close();
            } catch (NumberFormatException ex) {
                Toast.show("Wprowadź prawidłową liczbę", "error");
            }
        });

        cancelBtn.setOnAction(e -> modalStage.close());
        buttonBox.getChildren().addAll(thresholdBtn, cancelBtn);
        modalContent.getChildren().addAll(titleLabel, thresholdLabel, thresholdField, buttonBox);

        Scene modalScene = new Scene(modalContent, 300, 200);
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