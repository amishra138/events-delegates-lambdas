# C# Events - Delgates - Lambdas

# What is Event?
* Events are notifications
* Its a message that goes to one or more objects
* Play a central role in the .net framework
* Provide a way to trigger notifcations from end users or from objects
* Events signal the occurrence of an action/notification
* Objects that raise events don't need to explicitly know the object that will handle the event
* Events pass EventArgs (event data), it could be empty, one or many

# What is Delegate?
* Delegates is the pipeline between Event (raiser) and Event Handler (listener)
* A delegate is a specialized class often called a "Function Pointer"
* Based on a MulticastDelegate base class
* The Event raiser sends args via delegates to Event handler
* Ex: Button -> Click Event Raised -> Delegate -> Method Handles Click Event

public void btnSubmit_Click(object sender, EventArgs e) {
	//Handling of button click occurs
}

# What is an Event Handler?
* Event handler is responsible for receiving and processing data from a delegate
* Normally receives two parameters
	- Sender
	- EventArgs
* EventArgs responsible for encapsulating event data