# StaticAndInstanceField

An Instance Can Reference a Static, But not Vice Versa

We have no way of knowing what instance is being referenced by this static method, and neither does the compiler. 
That is why a static method can only access other static methods and properties.
However, the inverse is possible, which is to say that an instance method can access a static property. 
Here, we’re creating a simple static property that can count each time a new instance of type Valuation is created:
