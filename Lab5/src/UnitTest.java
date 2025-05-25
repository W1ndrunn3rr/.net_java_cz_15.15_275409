import org.junit.Test;
import static org.junit.jupiter.api.Assertions.*;
import java.util.List;

public class UnitTest {

    private final List<Item> testItems = List.of(
            new Item(0, 10, 1),
            new Item(1, 20, 5),
            new Item(2, 30, 10),
            new Item(3, 5, 2)
    );

    @Test
    public void shouldTakeBestItemMultipleTimes() {
        Problem problem = new Problem(testItems);
        Result result = problem.solve(5);

        assertEquals(50, result.sumValue);
        assertEquals(5, result.sumWeight);
        assertEquals(List.of(0, 0, 0, 0, 0), result.backpack());
    }

    @Test
    public void shouldTakeMixOfItems() {
        Problem problem = new Problem(testItems);
        Result result = problem.solve(11);

        assertEquals(110, result.sumValue);
        assertEquals(11, result.sumWeight);
    }

    @Test
    public void shouldHandleZeroCapacity() {
        Problem problem = new Problem(testItems);
        Result result = problem.solve(0);

        assertEquals(0, result.sumValue);
        assertEquals(0, result.sumWeight);
        assertTrue(result.backpack().isEmpty());
    }

    @Test
    public void shouldHandleEmptyItemList() {
        Problem problem = new Problem(List.of());
        Result result = problem.solve(100);

        assertEquals(0, result.sumValue);
        assertEquals(0, result.sumWeight);
        assertTrue(result.backpack().isEmpty());
    }

    @Test
    public void shouldNotExceedCapacity() {
        Problem problem = new Problem(testItems);
        Result result = problem.solve(7);

        assertTrue(result.sumWeight <= 7);
        assertEquals(70, result.sumValue);
        assertEquals(7, result.sumWeight);
    }

    @Test
    public void shouldChooseOptimalCombination() {
        List<Item> items = List.of(
                new Item(0, 5, 3),
                new Item(1, 9, 4),
                new Item(2, 15, 8)
        );

        Problem problem = new Problem(items);
        Result result = problem.solve(8);

        assertEquals(18, result.sumValue);
        assertEquals(8, result.sumWeight);
        assertEquals(List.of(1, 1), result.backpack());
    }
}