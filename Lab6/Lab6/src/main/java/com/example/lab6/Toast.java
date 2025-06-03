package com.example.lab6;

import javafx.animation.PauseTransition;

import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.layout.StackPane;
import javafx.scene.paint.Color;
import javafx.stage.Stage;
import javafx.stage.StageStyle;
import javafx.util.Duration;


public class Toast {

    public static void show(String message, String type) {
        Stage toastStage = new Stage();
        toastStage.initStyle(StageStyle.TRANSPARENT);

        StackPane root = getStackPane(message, type);

        Scene scene = new Scene(root);
        scene.setFill(Color.TRANSPARENT);
        toastStage.setScene(scene);
        toastStage.setAlwaysOnTop(true);
        toastStage.show();

        PauseTransition delay = new PauseTransition(Duration.seconds(3));
        delay.setOnFinished(event -> toastStage.close());
        delay.play();

        toastStage.setX((javafx.stage.Screen.getPrimary().getVisualBounds().getWidth() - root.getWidth()) / 2);
        toastStage.setY(javafx.stage.Screen.getPrimary().getVisualBounds().getHeight() * 0.8);
    }

    private static StackPane getStackPane(String message, String type) {
        Label toastLabel = new Label(message);
        toastLabel.setStyle("-fx-font-size: 14px; -fx-font-weight: bold; -fx-padding: 10 20 10 20;");

        switch (type) {
            case "success":
                toastLabel.setStyle(toastLabel.getStyle() + "-fx-background-color: #4CAF50; -fx-text-fill: white;");
                break;
            case "error":
                toastLabel.setStyle(toastLabel.getStyle() + "-fx-background-color: #F44336; -fx-text-fill: white;");
                break;
            case "warning":
                toastLabel.setStyle(toastLabel.getStyle() + "-fx-background-color: #FFC107; -fx-text-fill: black;");
                break;
            default:
                toastLabel.setStyle(toastLabel.getStyle() + "-fx-background-color: #333; -fx-text-fill: white;");
        }

        StackPane root = new StackPane(toastLabel);
        root.setStyle("-fx-background-radius: 5; -fx-padding: 10;");
        root.setOpacity(0.9);
        return root;
    }
}