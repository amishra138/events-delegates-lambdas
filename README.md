# C# Events - Delgates - Lambdas

# What is Delegate?
* A delegate is a specialized class often called a "Function Pointer"
* Delegates is the pipeline between Event (raiser) and Event Handler (listener)
* A delegate is a blueprint for method that data is going to get dumped into the handler
* Based on a MulticastDelegate base class
* The Event raiser sends args via delegates to Event handler
* Delegate.Combine, add what this does is take our delegate that we already have and adds in the value here
* Deleate.Remove, remove the delegate from the invocation list
* Ex: Button -> Click Event Raised -> Delegate -> Method Handles Click Event

public void btnSubmit_Click(object sender, EventArgs e) {
	//Handling of button click occurs
}
* Delegate base class, Delegate has two important properties and one method
	- Method : It is the pipeline has to dump data somewhere and you have to define the name of method, where data should go.
	- Target : The target would be if you have to an object instance where that method lives, then the target would be actual object that has that method.
	- GetInvocationList() : That ties in the next base class, there is a class called MulticastDelegate that's build into the framework as well.

* Every delegate we create, once it's compiled, will inherit from MulticastDelegate. Its really a way to hold multiple delegates.
* As mentioned in above line, we can't inherit directly from Delegate or MulticastDelegate, the way we do it is by delegate keyword and kind of a compiler trick
* When we create a delegate, compiler automatically create a new special class behind the scene which inherits multicast delegate

Ex: 
1) Delegate - public delegate void WorkPerformedHandler(int hours, WorkType workType)
2) Delegate Instance - WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
3) Handler - 
			static void WorkPerformed1(int hours, WorkType workType)
			{
				Console.WriteLine("WorkPerformed1 Called");
			}
4) Invoke - del1(5, WorkType.Golf); it will invoke dynamically at run time

* We use += to add multiple delegates in the Invocation List
	WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
	WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

	del1 += del2;

	del1(5, WorkType.GoToMeetings); //this will invoke both delegates, by this we can wire up a bunch of notifications

# What is a Multicast Delegate?
* Can reference more than one delegate function
* Tracks delegate references using an invocation list
* Delegates in the list are invoked sequentially
* It's a synchronous process, and process from top of the list to bottm
* In case of delegate with return type, last delegate in the invocation list will hold value and return to the caller

# What is Event?
* Events are notifications
* Its a message that goes to one or more objects
* Play a central role in the .net framework
* Provide a way to trigger notifcations from end users or from objects
* Events signal the occurrence of an action/notification
* Objects that raise events don't need to explicitly know the object that will handle the event
* Events pass EventArgs (event data), it could be empty, one or many
* Events are really friendly wrappers around delegates
* Events are raised by calling the event like a method:
* An event can be cast as delegate, because behind the scene its using delegate

Ex- public event WorkPerformedHandler WorkPerformed; (where WorkPerformedHandler is delegate)

# What is an Event Handler?
* Event handler is responsible for receiving and processing data from a delegate
* Normally receives two parameters
	- Sender
	- EventArgs
* EventArgs responsible for encapsulating event data
* To listen to an event you must construct a delegate and add it to the invocation list


# Delegate Inference
It allows us to directly assign method name to delegate without wrapping it to the delegate,When we assign a method name to a delegate, the compiler first infers the delegate's type.

For ex: Below code can be simplified
			var worker = new WorkerWithAdvance();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker.Worker_WorkPerformed);
            worker.WorkCompleted += new EventHandler(worker.Worker_WorkCompleted);
            worker.DoWork(2, WorkType.GenerateReports);
Simplified Code:
			var worker = new WorkerWithAdvance();
            worker.WorkPerformed += worker.Worker_WorkPerformed; //Attach events
            worker.WorkCompleted += worker.Worker_WorkCompleted;

			worker.WorkCompleted += worker.Worker_WorkCompleted; //Detach events
            worker.DoWork(2, WorkType.GenerateReports);

# Attaching event handlers directly to Events

What if you want to attach an event handler directly to an event?

			var worker = new WorkerWithAdvance();
            worker.WorkPerformed += worker.Worker_WorkPerformed; //Attach events

			public void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
			{
				Console.WriteLine(e.Hours.ToString());
			}

* By using Anonymous method, it allow event handler code to be hooked directly to an event.
 Anonymous methods are defined using the delegate keyword

			var worker = new WorkerWithAdvance();
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
			{
				Console.WriteLine(e.Hours.ToString());
			}

*Use when we have simple function and don't want to use anywhere.