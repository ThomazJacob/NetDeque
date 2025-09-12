using System.Diagnostics.CodeAnalysis;
using NetDeque;

namespace NetDequeTests;

public class DequeShould
{
    #region Estado Inicial
    [Fact]
    public void CountShouldBeZero()
    {
        var sut = new Deque<string>();
        
        Assert.Equal(0, sut.Count);
    }
    
    [Fact]
    public void IsEmptyShouldBeTrue()
    {
        var sut = new Deque<string>();
        
        Assert.True(sut.IsEmpty);
    }
    #endregion

    #region Inserções no início
    [Fact]
    public void AddElementToTheBeginningOfTheDequeCorrectly()
    {
        var sut = new Deque<string>();
        sut.AddBeg("element");
       
        Assert.Equal("element", sut.PeekBeg());
    }

    [Fact]
    public void AddMultipleElementsToTheBeginningAndRemoveThemInOrderFromTheBeginning()
    {
        var sut = new Deque<string>();
          
        sut.AddBeg("element1");
        sut.AddBeg("element2");
        sut.AddBeg("element3");
          
        Assert.Equal("element3", sut.RemBeg());
    }
    #endregion
      
    #region Inserções no final
    [Fact]
    public void AddElementToTheEndOfTheDequeCorrectly()
    {
        var sut = new Deque<string>();
        
        sut.AddEnd("element");
          
        Assert.Equal("element", sut.PeekEnd());
    }

    [Fact]
    public void AddMultipleElementsToTheEndAndRemoveThemInOrderFromTheEnd()
    {
        var sut = new Deque<string>();
        sut.AddEnd("element1");     
        sut.AddEnd("element2");     
        sut.AddEnd("element3");
          
        Assert.Equal("element3", sut.RemEnd());
    }
    #endregion
    
    #region Remoções no Início
    [Fact]
    public void RemoveElementFromEmptyDequeShouldThrowInvalidOperationException()
    {
        var sut = new Deque<string>();
        
        Assert.Throws<InvalidOperationException>(() => sut.RemBeg());
    }
    
    [Fact]
    public void RemoveElementFromTheBeginningOfTheDequeCorrectly()
    {
        var sut = new Deque<string>();
        sut.AddBeg("element1");
        sut.AddBeg("element2");
        sut.AddBeg("element3");
        
        Assert.Equal("element3", sut.RemBeg());
        Assert.Equal("element2", sut.RemBeg());
        Assert.Equal(1, sut.Count);
    }

    [Fact]
    public void RemoveMultipleElementsFromTheBeginningAndRemoveThemInOrderFromTheBeginning()
    {
        var sut = new Deque<string>();  
        sut.AddBeg("element1"); 
        
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
        Assert.Equal("element3", sut.RemEnd());
        Assert.Equal("element2", sut.RemEnd());
        
        Assert.Equal(1, sut.Count);
    }
    #endregion
    
    #region Espiadas    
    #endregion
  
    
    
    
    /*
    6. Espiadas (PeekBeg e PeekEnd)
    PeekBeg em um deque vazio deve lançar InvalidOperationException .
        PeekEnd em um deque vazio deve lançar InvalidOperationException .
        Inserir elementos e verificar se PeekBeg e PeekEnd retornam os valores corretos sem removê-
    los.
        Garantir que Count não seja alterado após um Peek .
*/
    
/*
     
    7. Cenários mistos
    Inserir no início e no final intercaladamente e verificar a consistência da ordem.
        Remover do início após inserir no final (e vice-versa), garantindo comportamento correto.
        Verificar que após várias operações de inserção e remoção, o deque ainda mantém o estado
    consistente (sem elementos "fantasmas").
      
      
        8. Teste de integridade geral
    Enfileirar e desenfileirar grandes quantidades de elementos em ambos os lados e verificar se
    todos os elementos corretos foram mantidos e removidos.
    
    9. TESTE EXTRA?!? adicionar no começo e remover no final e verificar que o count não muda porém o último elemento é alterado
    
    */
    
    
}