# DataGrid (WPF control)

`DataGrid` is a WPF control that can display data in a tabular format (think Excel spreadsheet)

## Default Binding using `ItemsSource`

XAML

```xaml
<Grid>
  <DataGrid Name="myDataGrid"></DataGrid>
</Grid>
```
In C#:
```csharp
public partial class MainWindow: Window
{
	public MainWindow()
	{
		InitializeComponent();

		List<User> users = new List<User>();
		users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
		users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
		users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

		myDataGrid.ItemsSource = users;
	}
}

public class User
{
	public int Id { get; set; }
	public string Name { get; set; }
	public DateTime Birthday { get; set; }

}

```

* Automatically generates columns based on the data (with sorting built in)
* One column per property in the Class of objects set as the `ItemsSource`.
* One row per object in the List set as the `ItemsSource`.
* Properties must have `get`/`set` specified, even if it is to the default (`{ get; set; }`)
* `DataGrid` allows the user to change the values which changes the data source.

**You cannot format a column if `AutoGenerateColumns` is `true`**

## Customize the Columns and Binding Properties in XAML

Suppose you don't want to have the `Id` column.

* `AutoGenerateColumns` property on the `DataGrid` needs to be set to false.	

To bind the data, using `"{Binding `*`PropertyName`*`}`"

```xaml
        <DataGrid Name="myDataGrid" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                <DataGridTextColumn Header="Birthday" Binding="{Binding Birthday, StringFormat=\{0:yyyy/MM/dd\}}"/>
            </DataGrid.Columns>
        </DataGrid>
```



## Customizing the Columns and Binding Properties in C#

```csharp
 List<User> users = new List<User>();
 users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
 users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
 users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

 myDataGrid.ItemsSource = users;
 myDataGrid.Columns.Clear();           			// Clear all existing columns on the DataGrid control.
 var column = new DataGridTextColumn();     // Create a text column object 
 column.Header = "My Column Header";				
 column.Binding = new Binding("Name");			// Bind to an object propery         

myDataGrid.Columns.Add(column);             // Add the defined column to the DataGrid
```



## Make Columns and Bind Data from Dictionary

```csharp
List<Dictionary<string, object>> populations = new List<Dictionary<string, object>>() {
    new Dictionary<string, object>() { { "Name", "Main City" }, { "Population", 12902 } },
    new Dictionary<string, object>() { { "Name", "Second City" }, { "Population", 10102 } },
    new Dictionary<string, object>() { { "Name", "Third City" }, { "Population", 831 } },
};

myDataGrid.ItemsSource = populations;
myDataGrid.Columns.Clear();

// get list of column name from first dictionary in the list
// and create column and bind to dictionary element
foreach (string key in populations[0].Keys)
{
    var column = new DataGridTextColumn();
    column.Header = key;
    column.Binding = new Binding($"[{key}]"); // Notice the square brackets!
    myDataGrid.Columns.Add(column);
}
```



## Formatting the Cell

Make the population number right-aligned

```csharp
            List<Dictionary<string, object>> populations = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>() { { "Name", "Main City" }, { "Population", 12902 } },
                new Dictionary<string, object>() { { "Name", "Second City" }, { "Population", 10102 } },
                new Dictionary<string, object>() { { "Name", "Third City" }, { "Population", 831 } },
            };


            myDataGrid.ItemsSource = populations;
            myDataGrid.Columns.Clear();

            // create columns
            var col1 = new DataGridTextColumn();
            col1.Header = "Town Name";
            col1.Binding = new Binding("[Name]");
            myDataGrid.Columns.Add(col1);

            var col2 = new DataGridTextColumn();
            col2.Header = "Population";
            col2.Binding = new Binding("[Population]");
            myDataGrid.Columns.Add(col2);

            // create a new style
            Style rightAligned = new Style();
            rightAligned.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));

            // set the population column to right aligned
            col2.CellStyle = rightAligned;
```



# DataGrid and Context Menu

XAML

```xaml
       <DataGrid Name="myDataGrid" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                <DataGridTextColumn Header="Birthday" Binding="{Binding Birthday, StringFormat=\{0:yyyy/MM/dd\}}"/>
            </DataGrid.Columns>
            <DataGrid.ContextMenu>
                <ContextMenu>
                    <MenuItem Click="MenuItem_Click" Header="Click Me"></MenuItem>
                </ContextMenu>
                
            </DataGrid.ContextMenu>
        </DataGrid>
```

C#

```csharp
		public MainWindow()
		{
			InitializeComponent();

			List<User> users = new List<User>();
			users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
			users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
			users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

			myDataGrid.ItemsSource = users;
		}
		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			// the selected object will always be a of the type that was originally put in the ItemsSource
			var selected = myDataGrid.SelectedItem as User;
			if (selected != null)
			{
				MessageBox.Show($"{selected.Name}'s birthday is {selected.Birthday}");
			}
		}
	}

	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Birthday { get; set; }

	}

```

