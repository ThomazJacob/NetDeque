using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using FluentAssertions;
using NetDeque;

namespace NetDequeTests;

public class DequeShould
{
    #region Estado Inicial
    [Fact]
    public void CountShouldBeZero()
    {
        var sut = new Deque<string>();
        
        //Assert.Equal(0, sut.Count);
        sut.Count.Should().Be(0);
    }
    
    [Fact]
    public void IsEmptyShouldBeTrue()
    {
        var sut = new Deque<string>();
        
        //Assert.True(sut.IsEmpty);
        sut.IsEmpty.Should().BeTrue();
    }
    #endregion

    #region Inserções no início
    [Fact]
    public void AddElementToTheBeginningOfTheDequeCorrectly()
    {
        var sut = new Deque<string>();
        
        sut.AddBeg("element");
       
        //Assert.Equal("element", sut.PeekBeg());
        sut.PeekBeg().Should().Be("element");
    }

    [Fact]
    public void AddMultipleElementsToTheBeginningAndRemoveThemInOrderFromTheBeginning()
    {
        var sut = new Deque<string>();
          
        sut.AddBeg("element1");
        sut.AddBeg("element2");
        sut.AddBeg("element3");
          
        //Assert.Equal("element3", sut.RemBeg());
        sut.RemBeg().Should().Be("element3");
    }
    #endregion
      
    #region Inserções no final
    [Fact]
    public void AddElementToTheEndOfTheDequeCorrectly()
    {
        var sut = new Deque<string>();
        
        sut.AddEnd("element");
          
        //Assert.Equal("element", sut.PeekEnd());
        sut.PeekEnd().Should().Be("element");
    }

    [Fact]
    public void AddMultipleElementsToTheEndAndRemoveThemInOrderFromTheEnd()
    {
        var sut = new Deque<string>();
        
        sut.AddEnd("element1");     
        sut.AddEnd("element2");     
        sut.AddEnd("element3");
          
        //Assert.Equal("element3", sut.RemEnd());
        sut.RemEnd().Should().Be("element3");
    }
    #endregion
    
    #region Remoções no Início
    [Fact]
    public void RemoveElementFromEmptyDequeShouldThrowInvalidOperationException()
    {
        var sut = new Deque<string>();
        
        var action = () => sut.RemBeg();
        var action2 = () => sut.RemEnd();
        
        //Assert.Throws<InvalidOperationException>(action);
        action.Should().ThrowExactly<InvalidOperationException>();
        action2.Should().ThrowExactly<InvalidOperationException>();
    }
    
    [Fact]
    public void RemoveElementFromTheBeginningOfTheDequeCorrectly()
    {
        var sut = new Deque<string>();
        
        sut.AddBeg("element1");
        sut.AddBeg("element2");
        sut.AddBeg("element3");
        
        //Assert.Equal("element3", sut.RemBeg());
        //Assert.Equal("element2", sut.RemBeg());
        //Assert.Equal(1, sut.Count);
        sut.RemBeg().Should().Be("element3");
        sut.RemBeg().Should().Be("element2");
        sut.Count.Should().Be(1);
    }
    #endregion

    #region Remoções no Final

    [Fact]
    public void RemoveMultipleElementsFromTheEndAndRemoveThemInOrderFromTheEnd()
    {
        var sut = new Deque<string>();
        
        sut.AddEnd("element1");     
        sut.AddEnd("element2");     
        sut.AddEnd("element3");
        
        //Assert.Equal("element3", sut.RemEnd());
        //Assert.Equal("element2", sut.RemEnd());
        //Assert.Equal(1, sut.Count);
        sut.RemEnd().Should().Be("element3");
        sut.RemEnd().Should().Be("element2");
        sut.Count.Should().Be(1);
    }
    #endregion
    
    #region Espiadas   
    [Fact]
    public void PeekBegShouldThrowInvalidOperationExceptionWhenDequeIsEmpty()
    {
        var sut = new Deque<string>();
        
        var action = () => sut.PeekBeg();
        
        //Assert.Throws<InvalidOperationException>(action);
        action.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void PeekEndShouldThrowInvalidOperationExceptionWhenDequeIsEmpty()
    {
        var sut = new Deque<string>();
        
        var action = () => sut.PeekEnd();
        
        //Assert.Throws<InvalidOperationException>(action);
        action.Should().ThrowExactly<InvalidOperationException>();
    }
    
    [Fact]
    public void PeekBegShouldNotChangeCount()
    {
        var sut = new Deque<string>();
        
        sut.AddBeg("element1");
        sut.AddBeg("element2");
        sut.AddBeg("element3");
        
        sut.PeekBeg();
        
        //Assert.Equal(3, sut.Count);
        sut.Count.Should().Be(3);
    }

    [Fact]
    public void PeekEndShouldNotChangeCount()
    {
        var sut = new Deque<string>();
        
        sut.AddEnd("element1");
        sut.AddEnd("element2");
        sut.AddEnd("element3");
        
        sut.PeekEnd();
        
        //Assert.Equal(3, sut.Count);
        sut.Count.Should().Be(3);       
    }

    [Fact]
    public void PeekBegShouldReturnTheFirstElement()
    {
        var sut = new Deque<string>();
        
        sut.AddBeg("element1");
        sut.AddBeg("element2");
        sut.AddBeg("element3");
        
        // Assert.Equal("element3", sut.PeekBeg());
        // Assert.Equal(3, sut.Count);
        sut.PeekBeg().Should().Be("element3");
        sut.Count.Should().Be(3);       
    }

    [Fact]
    public void PeekEndShouldReturnTheLastElement()
    {
        var sut = new Deque<string>();
        
        sut.AddEnd("element1");
        sut.AddEnd("element2");
        sut.AddEnd("element3");
        
        // Assert.Equal("element3", sut.PeekEnd());
        // Assert.Equal(3, sut.Count);        
        sut.PeekEnd().Should().Be("element3");
        sut.Count.Should().Be(3);       
    }
    
    #endregion

    #region Cenários Mistos
    [Fact]
    public void AddBegAndRemEndShouldReturnTheLastElement()
    {
        var sut = new Deque<string>();
        
        sut.AddBeg("element1");
        sut.AddEnd("element2");
        
        // Assert.Equal("element2", sut.RemEnd());
        // Assert.Equal(1, sut.Count);
        sut.RemEnd().Should().Be("element2");
        sut.Count.Should().Be(1);       
    }

    [Fact]
    public void ReturnTheLastElementWhenAddBegAndRemEnd()
    {
        var sut = new Deque<string>();
        
        sut.AddBeg("element1");
        
        // Assert.Equal("element1", sut.RemEnd());
        sut.RemEnd().Should().Be("element1");
    }
    
    [Fact]
    public void ReturnTheFirstElementWhenAddEndAndRemBeg()
    {
        var sut = new Deque<string>();
        
        sut.AddEnd("element1");
        
        // Assert.Equal("element1", sut.RemBeg());
        sut.RemBeg().Should().Be("element1");
    }

    [Fact]
    public void MaintainTheStateConsistencyAfterMultipleOperations()
    {
        var sut = new Deque<string>();
        
        sut.AddBeg("element1");
        sut.AddEnd("element2");
        sut.AddBeg("element3");
        sut.AddEnd("element4");
        sut.AddBeg("element5");
        
        sut.RemBeg();
        sut.RemEnd();
        sut.RemBeg();
        sut.RemEnd();
        sut.RemBeg();
        
        // Assert.Equal(0, sut.Count);
        sut.Count.Should().Be(0);       
    }
    #endregion

    #region Testes de integridade geral
    [Fact]
    public void AddAndRemoveElementsFromBothSides()
    {
        var sut = new Deque<string>();
        
        sut.AddBeg("element1"); 
        sut.AddEnd("element2"); // 1, 2
        sut.AddBeg("element3"); // 3, 1, 2 
        sut.AddEnd("element4"); // 3, 1, 2, 4
        sut.AddBeg("element5"); // 5, 3, 1, 2, 4
        sut.AddEnd("element6"); // 5, 3, 1, 2, 4, 6
        sut.AddBeg("element7"); // 7, 5, 3, 1, 2, 4, 6
        sut.AddEnd("element8"); // 7, 5, 3, 1, 2, 4, 6, 8
        sut.AddBeg("element9"); // 9, 7, 5, 3, 1, 2, 4, 6, 8
        sut.AddEnd("element10"); // 9, 7, 5, 3, 1, 2, 4, 6, 8, 10
            
        for (int i = 0; i < 4; i++)
        {
            sut.RemBeg();
            sut.RemEnd();
        }
            
        // Assert.Equal("element1", sut.RemBeg());
        // Assert.Equal(1, sut.Count);
        // Assert.Equal("element2", sut.RemEnd());
        // Assert.Equal(0, sut.Count);
        sut.RemBeg().Should().Be("element1");
        sut.Count.Should().Be(1);
        sut.RemEnd().Should().Be("element2");
        sut.Count.Should().Be(0);       
    }
    #endregion
}