# Redwood

Redwood is a Usercontrol library written in C# to extend the DevExpress TreeList Usercontrol. 

The basic idea is to use attributes to annotate ViewModels which will be visualized by the tree.

## Attributes

### TreeNode(listValue)

Sets the tree node value, this is used on view models which provide data beneath their primary node.

### Scalar(valueName)

Annotates a scalar value in the ViewModel. If used on a type which is annotated by the TreeNode attribute, the data found inside the property is also added to the tree.

### SubList(listName)

Similar to Scalar Values, but used on lists of objects instead.

### ListValue

Used to define which property should be visually displayed as the value of this node. 

## Other notes

In the absence of any attributes, scalar values (and sublist values) use the ToString() method of the associated type.
