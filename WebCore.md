# View Component
- enhancement of partial view 
- partial view still have dependency on controller 
- View Component don't need a controller
- There's no model binding.
- A view component never handles a request.
## 
- the class name PriorityListViewComponent ends with the suffix ViewComponent, the runtime uses the string PriorityList when referencing the class component from a view.

## View search path
- the default view file Default.cshtml
- the Views/Shared/Components/{View Component Name}/{View Name} path.



# Invoking a view component as a Tag Helper
``` cshtml
<vc:[view-component-name]
  parameter1="parameter1 value"
  parameter2="parameter2 value">
</vc:[view-component-name]>
```
# Notes:
- _ViewStart.cshtml 
	- is a special view page containing the statement declaration to include the Layout page.
- _ViewImports.cshtml 
	- file is to provide a mechanism to centralise directives that apply to Razor pages so that you don't have to add them to pages individually.

# Ref
- https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-3.1
- https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-6.0

