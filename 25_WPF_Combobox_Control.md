# WPF Combobox Control

## Video links:

[Dropdown 1](https://drive.google.com/file/d/1NQmxWnmIfWiWuwdQJQyfgqxVB86jIwX4/view)

 [Dropdown 2](https://drive.google.com/file/d/1POUzzRhHZrv_f7qvqkSAicx1d8AwmpIc/view?usp=sharing)

[Youtube playlist on WPF](https://www.youtube.com/playlist?list=PLrkQ3hzZrc4jhO4Zpb3GVk6loXUKdDDcy)



## C# `Lists` Refresher

Arrays are of fixed size. 

```csharp
int[] myArray = new int[] { 1, 2, 3 };
```

Lists are objects that hold variables of a given type in a specific order.

* Lists are dynamically sized. 

* They also have more functionality.

* We can add elements to the List, it will adjust its size as needed. 

* Most larger programs use `Lists`, although they are not as efficient as `Array`s

  

C# Lists are initialized using the **new** keyword:

```csharp
using System.Collections.Generic;

List<int> myList = new List<int>();
List<int> myOtherList = new List<int>(){ 1, 2, 3 };

```

The angle brackets are part of the declaration type. They are not conditional (less or more than) operators.

### `List` Operations

```csharp
myList.Add( 5 );  //adds to the end of the list
myList.Remove( 5 );  //removes element
myList.RemoveAt( 0 );  //removes element at index
myList.Clear();  //removes all elements
myList.Count; // Property - number of elements
myList[index] // to access object at index

// Loop through a list:
foreach ( int item in myList )
{
         // do something with item
}

```



## ComboBox

ComboBox objects have a property: **`Items`**

* **`Items`** is a Collection I can add to.

  ```chsarp
  myComboBox.Items.Add(myObject)
  ```

* **`ItemsSource`** is a "collection" (*a `list` is a collection*)

  ```csharp
  myComboBox.ItemsSource = myList;
  ```



Other interesting properties:

* **`SelectedItem`**: the object that is currently selected in the combobox

  * It returns an *object*, so you must cast it to something if you want to do anything with it.

* **`SelectedIndex`**: the currently selected index 

  * returns an integer (-1 if nothing selected)

  

### Adding Items to a ComboBox

I have a bunch of instances of `Thing`. The `Thing` class has a `name` property.

```csharp
public string Name { get => _name; }
public int Age { get => _age; }

private string _name;
private int _age;

public Thing( string name, int age)
{
   _name = name;
   _age = age;
}
```

If I have a bunch of `Things` in a list:

```csharp
List<Thing> theThings = new List<Thing>( thing1, thing2, thing3)
```

#### Adding Items Using a Specific Property

I could add the names to my comboBox directly:

```csharp
foreach( Thing theThing in theThings)
{
  myComboBox.Items.Add( theThing.Name );
}
```

When the selection is changed (`SelectionChanged` event), 

* I could get what was selected and act upon it.  In this case, it would be a string, describing the `name` of `Thing`
* If all I have is the `name` property, I could:
  * somehow map back to the object itself. 
    * This can be unreliable (two objects with the same property?)
  * rely on a mapping in the order of the List and the order in the combo box: 
    * suppose `myComboBox.SelectedIndex` is 2, therefore `myList(2)` is the chosen object I could act upon. 
    * *This is very bad idea because a bug could be introduced very easily!!!*

#### Adding Items Using the Object Itself

I could add the object in the combo box directly, 

```csharp
foreach( Thing theThing in theThings)
{
  myComboBox.Items.Add( theThing );
}
```

or 

```charp
myComboBox.ItemsSource = theThings;
```



then I can act on it directly

```csharp
Thing selectedObject = myComboBox.SelectedItem as Thing; // cast the object to 'Thing'
```



#### Defining the Object String in the ComboBox

##### What Gets Displayed in the ComboBox for an Object Type?

Whatever the `ToString` method on that object returns.

*Default*: ObjectThing(address)

##### Create a `ToString` method for your object

If you have a class `Thing`, and you want to show only the property `name` in the combo box, you could add the following to your `Thing` class.

```csharp
public override string ToString()
{
  return name;
}

```

##### Specify the Property You Want to Show

Maybe you don't want to show whatever the `ToString` method returns, as you have no control over the code that defines the `ToString` method.

You can tell the `ComboBox` which `object` property you want to display in the dropdown list.

```csharp
myComboBox.DisplayMemberPath = "name"
```

The property

* **must exist**
* **must be public**

