package com.example.lab6;

import java.io.IOException;
import java.util.logging.FileHandler;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

public class FileLogger {
    private final Logger logger = Logger.getLogger("File Logger");

    public FileLogger() {
        try {
            FileHandler fileHandler = new FileHandler("Logs.txt", true);
            logger.addHandler(fileHandler);
            SimpleFormatter formatter = new SimpleFormatter();
            fileHandler.setFormatter(formatter);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void Log(String message, int logLevel) {
        switch (logLevel) {
            case 1:
                logger.info(message);
                break;
            case 2:
                logger.warning(message);
                break;
            case 3:
                logger.severe(message);
        }
    }
}