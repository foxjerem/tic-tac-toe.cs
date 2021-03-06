using NUnit.Framework;

namespace TicTacToeComponents
{
  [TestFixture]
  //Space class tests
  public class SpaceTest
  {
    Space space;
    char mark;

    [SetUp]
    public void Init()
    {
      space = new Space();
    }

    [Test]
    //Space can be marked
    public void Mark()
    {
      mark = 'X';
      space.Mark(mark);

      Assert.AreEqual(mark, space.Content);
    }

    [Test]
    //Boolean IsEmpty method
    public void IsEmpty()
    {
      Assert.IsTrue(space.IsEmpty());
      
      space.Mark('X');
      
      Assert.IsFalse(space.IsEmpty());
    }
  }

  [TestFixture]
  //Grid class tests
  public class GridTest
  {
    Grid grid;

    [SetUp]
    public void Init()
    {
      grid = new Grid();
    }

    [Test]
    //Grid holds 3x3 spaces
    public void Spaces()
    {
      CollectionAssert.AllItemsAreInstancesOfType(grid.Spaces, typeof(Space));
    }

    [Test]
    //Grid can be printed to a string
    public void Display()
    {
      string expectedStr = "X | - | -\n- | - | -\n- | - | -\n";
      char mark = 'X';

      grid.Spaces[0,0].Mark(mark);

      Assert.AreEqual(expectedStr, grid.Display());
    }

  }

  [TestFixture]
  //Player class tests
  public class PlayerTest
  {
    Player player;

    [SetUp]
    public void Init()
    {
      player = new Player("Jeremy", 'X');
    }

    [Test]
    //Name attribute
    public void Name()
    {
      Assert.AreEqual("Jeremy", player.Name);
    }

    [Test]
    //Mark attribute
    public void XorO()
    {
      Assert.AreEqual('X', player.XorO);
    }

    [Test]
    //Player can mark the grid
    public void MarkGrid()
    {
      Grid grid = new Grid();

      player.MarkGridAt(1,2, grid);

      Assert.AreEqual('X', grid.Spaces[1,2].Content);
    }
  }
}