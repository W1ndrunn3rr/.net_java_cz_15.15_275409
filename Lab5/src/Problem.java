import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Random;

public class Problem {
    private final List<Item> itemList;
    public Problem(int n, int seed) {
        this.itemList = new ArrayList<>();
        Random rand = new Random(seed);
        for (int i = 0; i < n; i++) {
            int value = rand.nextInt(10) + 1;
            int weight = rand.nextInt(10) + 1;
            itemList.add(new Item(i, value, weight));
        }
    }
    public Problem(List<Item> items) {
        this.itemList = new ArrayList<>(items);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (Item item : itemList) {
            sb.append(item.id())
                    .append(". Wartość: ")
                    .append(item.value())
                    .append(" | Waga: ")
                    .append(item.weight())
                    .append("\n");
        }
        return sb.toString();
    }
    public Result solve(int capacity) {
        Result result = new Result();
        List<Item> sortedItems = new ArrayList<>(itemList);

        sortedItems.sort(Comparator.comparingDouble(
                (Item item) -> (double) item.value() / item.weight()
        ).reversed());

        for (Item item : sortedItems) {
            while (item.weight() <= capacity) {
                result.backpack().add(item.id());
                result.sumValue += item.value();
                result.sumWeight += item.weight();
                capacity -= item.weight();

                if (capacity == 0) {
                    return result;
                }
            }
        }
        result.itemCount = result.backpack().size();
        return result;
    }
}