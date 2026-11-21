# TECH DAY 2025 - Instructions for Grocery List App



## Let's make the list stand out. 🟡


```c#
Background="yellow"
```



## How do I remove an item? ❌


```c#
            
            GroceryList.Items.RemoveAt(1);
```



## But what if I did not want to remove the specific one!??


```c#
            
            GroceryList.Items.Remove(GroceryList.SelectedItem);
```

### Should I make sure the user knows what they are doing??

                MessageBoxResult result = MessageBox.Show(
                                    $"Are you sure????",
                                    "Confirm Delete",
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Warning);
    
                if (result == MessageBoxResult.Yes)
                {
                    GroceryList.Items.Remove(item);
                }

## It would be nice to know that I need two bags of apples not just one.

Add this after the TextBox in **MainWindow.xaml**


```c#
            
      
        <TextBlock Text="Quantity:" FontWeight="Bold"/>
        <TextBox Name="QuantityTextBox" Margin="0,5" Width="60"/>
```

In **MainWindow.xaml.cs** go to **AddItemToList** and remove ❌


```c#
        GroceryList.Items.Add(item);
```

In **AddItemToList** add this instead:


```c#
           string qty = string.IsNullOrWhiteSpace(QuantityTextBox.Text) ? "1" : QuantityTextBox.Text;

           GroceryList.Items.Add($"{item} (x{qty})");

           QuantityTextBox.Clear();
```



## Let's add a random treat!

Add 5 of your favourite treats to **myTreats** at the top of **MainWindow.xaml.cs**


```c#
        public MainWindow()
        {
            InitializeComponent();

            myTreats.Add("Oh Henry");
            myTreats.Add("YOURS 1");
            myTreats.Add("YOURS 2");
        }
```



Add this code inside **AddRandomTreat_Click** in **MainWindow.xaml.cs**


```c#
            Random random = new Random();
            int randomIndex = random.Next(myTreats.Count);
            string randomTreat = myTreats[randomIndex];

            AddItemToList(randomTreat);

```





## Print out my grocery list? Let's add another button!


```c#
<Button Content="" Width="140" Margin="0,5"/>
```



## What should it do?  Print the list! 🖨️🖨️


```c#
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(GroceryList, "My First Print Job");
            }
```
