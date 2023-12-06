//public class Editor
//{
//    public string Content { get; set; }

//    public EditorMemento CreateMemento()
//    {
//        return new EditorMemento(Content);
//    }

//    public void RestoreMemento(EditorMemento memento)
//    {
//        Content = memento.Content;
//        Console.WriteLine($"Restored editor content to: {Content}");
//    }
//}


//public class EditorMemento
//{
//    public string Content { get; }

//    public EditorMemento(string content)
//    {
//        Content = content;
//    }
//}
//class Program
//{
//    static void Main()
//    {
//        var editor = new Editor();
//        // Metin düzenleyiciyi oluşturalım

//        // Metin düzenleyiciye içerik ekleyelim
//        editor.Content = "Hello, World!";

//        // Durumu kaydedelim
//        var memento = editor.CreateMemento();

//        // İçeriği değiştirelim
//        editor.Content = "New content";

//        // Durumu geri yükleyelim
//        editor.RestoreMemento(memento);
//    }
//}








//**************************************** example 2 ****************************************************

using System;
using System.Collections.Generic;

// Originator: Class representing the text editor
class TextEditor
{
    private string content;
    private List<TextEditorMemento> mementos = new List<TextEditorMemento>();

    public string Content
    {
        get { return content; }
        set
        {
            Console.WriteLine($"Text editor content changed: {value}");
            content = value;
            SaveMemento();
        }
    }

    // Create a memento and add it to the list
    private void SaveMemento()
    {
        mementos.Add(new TextEditorMemento(content));
    }

    // Restore from the memento at a specific index
    public void RestoreMemento(int index)
    {
        if (index >= 0 && index < mementos.Count)
        {
            content = mementos[index].Content;
            Console.WriteLine($"Text editor content restored: {content}");
        }
        else
        {
            Console.WriteLine("Invalid index");
        }
    }
}

// Memento: Class representing the state of the text editor
class TextEditorMemento
{
    public string Content { get; }

    public TextEditorMemento(string content)
    {
        Content = content;
    }
}

class Program
{
    static void Main()
    {
        // Create a text editor
        TextEditor textEditor = new TextEditor();

        // Scenario: Change the text and save the state
        textEditor.Content = "This is a test text.";
        textEditor.Content = "Text editor example.";
        textEditor.Content = "Final state.";

        // Restore the state
        textEditor.RestoreMemento(0); // "This is a test text."
        textEditor.RestoreMemento(1); // "Text editor example."
        textEditor.RestoreMemento(2); // "Final state."
        textEditor.RestoreMemento(3); // Invalid index
    }
}








//using System;

//// State arayüzü
//public interface IState
//{
//    void Handle(Context context);
//}

//// ConcreteState sınıfları
//public class ConcreteStateA : IState
//{
//    public void Handle(Context context)
//    {
//        Console.WriteLine("State A handling the request.");
//        // State A'nın davranışı burada tanımlanır
//        context.State = new ConcreteStateB(); // State değişimi
//    }
//}

//public class ConcreteStateB : IState
//{
//    public void Handle(Context context)
//    {
//        Console.WriteLine("State B handling the request.");
//        // State B'nin davranışı burada tanımlanır
//        context.State = new ConcreteStateA(); // State değişimi
//    }
//}

//// Context sınıfı
//public class Context
//{
//    private IState state;

//    public Context(IState initialState)
//    {
//        state = initialState;
//    }

//    public IState State
//    {
//        get { return state; }
//        set
//        {
//            state = value;
//            Console.WriteLine($"State changed to {state.GetType().Name}");
//        }
//    }

//    public void Request()
//    {
//        state.Handle(this);
//    }
//}

//// Kullanım örneği
//class Program
//{
//    static void Main()
//    {
//        // Başlangıç durumuyla bir Context oluşturuluyor
//        var context = new Context(new ConcreteStateA());

//        // İsteği gerçekleştiriyoruz, State A davranışı çalışacak
//        context.Request();

//        // İsteği tekrar gerçekleştiriyoruz, bu sefer State B davranışı çalışacak
//        context.Request();
//    }
//}



