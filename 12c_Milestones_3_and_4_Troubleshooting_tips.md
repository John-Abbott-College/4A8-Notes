# Milestones 3 and 4 - Troubleshooting tips

#### The unit tests do not see the HomeCalendar code?

Is the unit tests project able to access the code? Adding a project reference ensures this.




#### The unit tests do not see the HomeCalendar code?

Is the unit tests project able to access the code? Adding a project reference ensures this.




#### Run the tests and see errors about sqlite3 not being found?

The unit tests run the sqlite command. The executable needs to be accessible to VS. Make sure it is in your user account path.




#### Run the tests and see errors about Database.dbConnection being null?

Are you sure your code is setting it?




#### Tests run when you start them individually, but you see failures indicating that the database is in use running the test suite?

make sure that the xunit.runner.json file is in the unit test project, alongside the csproj file. Then add the following at the end of your xunit project's csproj file (right before the `</Project>` end tag, alongside the other `<ItemGroup>` elements):

```
<ItemGroup>
  <None Update="xunit.runner.json"> 
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```



#### You checked your tables using the command line tool, but the unit tests insist that the tables are incorrect?

Remember that you cannot have spaces in the path to your solution. Pull your team's repo onto a local path with no spaces. 
