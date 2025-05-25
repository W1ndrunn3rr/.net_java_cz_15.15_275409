import java.util.ArrayList;
import java.util.List;

public class Result {
    private final List<Integer> backpack = new ArrayList<>();
    public int sumValue;
    public int sumWeight;
    public int itemCount;

    public List<Integer> backpack() {
        return backpack;
    }

    @Override
    public String toString() {
        return "Przedmioty: " + backpack +
                "\nIlość przedmiotów: " + backpack.size() +
                "\nCałkowita wartość: " + sumValue +
                "\nWaga całkowita: " + sumWeight;
    }
}