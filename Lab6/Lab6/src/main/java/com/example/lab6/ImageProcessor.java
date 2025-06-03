package com.example.lab6;

import javafx.scene.image.Image;
import javafx.scene.image.PixelReader;
import javafx.scene.image.PixelWriter;
import javafx.scene.image.WritableImage;
import javafx.scene.paint.Color;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.*;


public class ImageProcessor {
    private static final int THREAD_COUNT = 4;
    private static final ExecutorService executor = Executors.newFixedThreadPool(THREAD_COUNT);

    public static Image createNegative(Image original) {
        int width = (int) original.getWidth();
        int height = (int) original.getHeight();

        WritableImage negativeImage = new WritableImage(width, height);
        PixelReader pixelReader = original.getPixelReader();
        PixelWriter pixelWriter = negativeImage.getPixelWriter();

        List<Future<?>> futures = new ArrayList<>();
        int rowsPerThread = height / THREAD_COUNT;

        for (int t = 0; t < THREAD_COUNT; t++) {
            final int startY = t * rowsPerThread;
            final int endY = (t == THREAD_COUNT - 1) ? height : (t + 1) * rowsPerThread;

            futures.add(executor.submit(() -> {
                for (int y = startY; y < endY; y++) {
                    for (int x = 0; x < width; x++) {
                        Color color = pixelReader.getColor(x, y);
                        Color negativeColor = new Color(
                                1.0 - color.getRed(),
                                1.0 - color.getGreen(),
                                1.0 - color.getBlue(),
                                color.getOpacity()
                        );
                        pixelWriter.setColor(x, y, negativeColor);
                    }
                }
            }));
        }

        waitForCompletion(futures);
        return negativeImage;
    }

    public static Image createThreshold(Image original, int threshold) {
        int width = (int) original.getWidth();
        int height = (int) original.getHeight();

        WritableImage thresholdImage = new WritableImage(width, height);
        PixelReader pixelReader = original.getPixelReader();
        PixelWriter pixelWriter = thresholdImage.getPixelWriter();

        double normalizedThreshold = threshold / 255.0;
        List<Future<?>> futures = new ArrayList<>();
        int rowsPerThread = height / THREAD_COUNT;

        for (int t = 0; t < THREAD_COUNT; t++) {
            final int startY = t * rowsPerThread;
            final int endY = (t == THREAD_COUNT - 1) ? height : (t + 1) * rowsPerThread;

            futures.add(executor.submit(() -> {
                for (int y = startY; y < endY; y++) {
                    for (int x = 0; x < width; x++) {
                        Color color = pixelReader.getColor(x, y);
                        double brightness = (color.getRed() + color.getGreen() + color.getBlue()) / 3.0;

                        Color newColor = brightness > normalizedThreshold ? Color.WHITE : Color.BLACK;
                        pixelWriter.setColor(x, y, newColor);
                    }
                }
            }));
        }

        waitForCompletion(futures);
        return thresholdImage;
    }

    public static Image createContours(Image original) {
        int width = (int) original.getWidth();
        int height = (int) original.getHeight();

        WritableImage contourImage = new WritableImage(width, height);
        PixelReader pixelReader = original.getPixelReader();
        PixelWriter pixelWriter = contourImage.getPixelWriter();

        List<Future<?>> futures = new ArrayList<>();
        int rowsPerThread = (height - 2) / THREAD_COUNT;

        for (int t = 0; t < THREAD_COUNT; t++) {
            final int startY = 1 + t * rowsPerThread;
            final int endY = (t == THREAD_COUNT - 1) ? height - 1 : 1 + (t + 1) * rowsPerThread;

            futures.add(executor.submit(() -> {
                for (int y = startY; y < endY; y++) {
                    for (int x = 1; x < width - 1; x++) {
                        double gx = 0, gy = 0;

                        gx += pixelReader.getColor(x-1, y-1).getBrightness() * -1;
                        gx += pixelReader.getColor(x-1, y).getBrightness() * -2;
                        gx += pixelReader.getColor(x-1, y+1).getBrightness() * -1;
                        gx += pixelReader.getColor(x+1, y-1).getBrightness() * 1;
                        gx += pixelReader.getColor(x+1, y).getBrightness() * 2;
                        gx += pixelReader.getColor(x+1, y+1).getBrightness() * 1;

                        gy += pixelReader.getColor(x-1, y-1).getBrightness() * -1;
                        gy += pixelReader.getColor(x, y-1).getBrightness() * -2;
                        gy += pixelReader.getColor(x+1, y-1).getBrightness() * -1;
                        gy += pixelReader.getColor(x-1, y+1).getBrightness() * 1;
                        gy += pixelReader.getColor(x, y+1).getBrightness() * 2;
                        gy += pixelReader.getColor(x+1, y+1).getBrightness() * 1;

                        double magnitude = Math.sqrt(gx * gx + gy * gy);
                        magnitude = Math.min(1.0, magnitude);

                        Color edgeColor = new Color(magnitude, magnitude, magnitude, 1.0);
                        pixelWriter.setColor(x, y, edgeColor);
                    }
                }
            }));
        }

        waitForCompletion(futures);
        return contourImage;
    }

    public static Image rotateImageByDegrees(Image original, int degrees) {
        int width = (int) original.getWidth();
        int height = (int) original.getHeight();

        WritableImage rotatedImage;
        PixelReader pixelReader = original.getPixelReader();
        PixelWriter pixelWriter;

        if (Math.abs(degrees) == 90) {
            rotatedImage = new WritableImage(height, width);
            pixelWriter = rotatedImage.getPixelWriter();

            List<Future<?>> futures = new ArrayList<>();
            int colsPerThread = width / THREAD_COUNT;

            for (int t = 0; t < THREAD_COUNT; t++) {
                final int startX = t * colsPerThread;
                final int endX = (t == THREAD_COUNT - 1) ? width : (t + 1) * colsPerThread;

                futures.add(executor.submit(() -> {
                    for (int x = startX; x < endX; x++) {
                        for (int y = 0; y < height; y++) {
                            Color color = pixelReader.getColor(x, y);
                            if (degrees == 90) {
                                pixelWriter.setColor(height - 1 - y, x, color);
                            } else { // degrees == -90
                                pixelWriter.setColor(y, width - 1 - x, color);
                            }
                        }
                    }
                }));
            }

            waitForCompletion(futures);
        } else {
            return original;
        }

        return rotatedImage;
    }

    public static Image scaleImage(Image original, int newWidth, int newHeight) {
        int originalWidth = (int) original.getWidth();
        int originalHeight = (int) original.getHeight();

        WritableImage scaledImage = new WritableImage(newWidth, newHeight);
        PixelReader pixelReader = original.getPixelReader();
        PixelWriter pixelWriter = scaledImage.getPixelWriter();

        double xRatio = (double) originalWidth / newWidth;
        double yRatio = (double) originalHeight / newHeight;

        List<Future<?>> futures = new ArrayList<>();
        int rowsPerThread = newHeight / THREAD_COUNT;

        for (int t = 0; t < THREAD_COUNT; t++) {
            final int startY = t * rowsPerThread;
            final int endY = (t == THREAD_COUNT - 1) ? newHeight : (t + 1) * rowsPerThread;

            futures.add(executor.submit(() -> {
                for (int y = startY; y < endY; y++) {
                    for (int x = 0; x < newWidth; x++) {
                        int sourceX = (int) (x * xRatio);
                        int sourceY = (int) (y * yRatio);

                        sourceX = Math.min(sourceX, originalWidth - 1);
                        sourceY = Math.min(sourceY, originalHeight - 1);

                        Color color = pixelReader.getColor(sourceX, sourceY);
                        pixelWriter.setColor(x, y, color);
                    }
                }
            }));
        }

        waitForCompletion(futures);
        return scaledImage;
    }

    private static void waitForCompletion(List<Future<?>> futures) {
        for (Future<?> future : futures) {
            try {
                future.get();
            } catch (InterruptedException | ExecutionException e) {
                Thread.currentThread().interrupt();
                throw new RuntimeException("Błąd podczas przetwarzania równoległego", e);
            }
        }
    }

    public static void saveImage(Image image, Path outputPath) throws IOException {
        int width = (int) image.getWidth();
        int height = (int) image.getHeight();

        BufferedImage bufferedImage = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);

        PixelReader reader = image.getPixelReader();
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                javafx.scene.paint.Color fxColor = reader.getColor(x, y);
                java.awt.Color awtColor = new java.awt.Color(
                        (float) fxColor.getRed(),
                        (float) fxColor.getGreen(),
                        (float) fxColor.getBlue(),
                        (float) fxColor.getOpacity()
                );
                bufferedImage.setRGB(x, y, awtColor.getRGB());
            }
        }
        ImageIO.write(bufferedImage, "jpg", outputPath.toFile());
    }

}