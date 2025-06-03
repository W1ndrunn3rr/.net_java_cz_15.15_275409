import java.util.Scanner;
import java.util.Random;

public class Main {
    public static void main(String[] args) {
        String userInput;
        int seed, itemCount, capacity;

        Random rng = new Random();

        try (Scanner scanner = new Scanner(System.in)) {

            System.out.println("Podaj ziarno generatora liczb (lub wciśnij Enter, aby wylosować): ");
            userInput = scanner.nextLine();
            seed = userInput.isEmpty() ? rng.nextInt(Integer.MAX_VALUE) : Integer.parseInt(userInput);

            System.out.println("Podaj liczbę przedmiotów: ");
            itemCount = Integer.parseInt(scanner.nextLine());

            System.out.println("Podaj pojemność plecaka (lub wciśnij Enter, aby wylosować): ");
            userInput = scanner.nextLine();
            capacity = userInput.isEmpty() ? rng.nextInt(Integer.MAX_VALUE) : Integer.parseInt(userInput);

            System.out.println("\n-------------------------" +
                    "\nINFORMACJE:" +
                    "\nPojemność plecaka: " + capacity +
                    "\nZiarno generatora: " + seed +
                    "\nLiczba przedmiotów: " + itemCount +
                    "\n-------------------------\n");


            seed = Math.max(seed, 0);
            itemCount = itemCount > 0 ? itemCount : Integer.MAX_VALUE;

            Problem problem = new Problem(itemCount, seed);
            System.out.println("Lista dostępnych przedmiotów:\n" + problem.toString());

            Result wynik = problem.solve(capacity);
            System.out.println("\nRozwiązanie problemu plecakowego:\n" + wynik.toString());
        } catch (Exception e) {
            System.out.println("Wystąpił błąd: " + e.getMessage());
        }
    }
}