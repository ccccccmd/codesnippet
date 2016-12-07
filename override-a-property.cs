You need to use virtual keyword

abstract class Base
{
  // use virtual keyword
  public virtual int x
  {
    get { throw new NotImplementedException(); }
  }
}
or define an abstract property:

abstract class Base
{
  // use abstract keyword
  public abstract int x { get; }
}
and use override keyword when in the child:

abstract class Derived : Base
{
  // use override keyword
  public override int x { get { ... } }
}
If you're NOT going to override, you can use new keyword on the method to hide the parent's definition.

abstract class Derived : Base
{
  // use override keyword
  public new int x { get { ... } }
}


//from  http://stackoverflow.com/questions/8447832/can-i-override-a-property-in-c-how/8447846#8447846