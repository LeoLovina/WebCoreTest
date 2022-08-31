# View Component
- enhancement of partial view 
- partial view still have dependency on controller 
- View Component don't need a controller
- There's no model binding.
- A view component never handles a request.
## 

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



