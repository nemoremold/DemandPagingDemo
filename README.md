# Project Icebox Document


## Request Paging Storage Management Simulator
### Project Icebox
#### Product Name: Icebox Request Paging Storage Management Simulator
#### Product Version: Alpha
#
### Product Development History
#### 2017/5/24:
v0.1: basic C# testing demo launched by Yaxuan LANYU;

v0.2: project created by Yaxuan LANYU;

v0.3: basic class of the simulator designed by Yaxuan LANYU after looking up meterials about storage management and least recently used algorithm;

v0.4: entity classes implemented by Yaxuan LANYU;

v0.5: LRU & control class implemented by Yaxuan LANYU;


#### 2017/5/25:
v0.6: basic UI designed by Yaxuan LANYU;

v0.7: basic boundary classes implemented by Yaxuan LANYU;

v0.8: UIControl functionality implemented by Yaxuan LANYU, intergrating the whole project;

v0.9 patches: several optimization functionalities added by Yaxuan LANYU and several logic bugs fixed by Yaxuan LANYU;

Alpha: project’s final development procedure finished, adding icons and form name, etc. By Yaxuan LANYU;


## Introduction to Product
### Open the Application
#### 1.Execute Icebox.exe with 1.ico in the same folder. 
NOTE: If 1.ico does not exist, an error message box will be presented. Should the message box appear, click continue to ignore it. Nothing will be influenced except for the icon shown on the top-left corner of the form.

#### 2.Open Icebox.sln in the Course Project’s VS2015 Solution folder with Visual Studio 2015 or later version of Visual Studio and do the run operation.
NOTE: Using later version of Visual Studio may cause unpredictable errors and warnings, user may need to optimize the code and fix the bugs himself.

#### NOTES: The program sometimes crashes on pressing “Stop” button while in the status of pausing the calculation or crashes on starting new process of calculation. When these situations happen, reopen the program and input again then press the “Run” button.

#
### About the Codes
The codes are stored both in the Course Project’s VS2015 Solution folder and Cource Project’s C# Codes folder. The former one contains the whole project’s solution while the later one’s contents are only optimized codes.

#### 1.Entity classes
a)Page.cs
Declaration and defination of entity class Page were implemented here. Page class stores the information of the Page, containing it’s number of pages, instructions in each page, total number of instructions that can be stored. The class entity also contains a 2 dimensional array storing the status of every page and every block in a page. The Page entity also initialize itself at instantiating, creating pages with random instructions.

b)MemoryBlock.cs
Declaration and defination of entity class MemoryBlock were implemented here. MemoryBlock entity stores the information of a block object, including it’s location in the pages, the instruction it is calling and the place where itself is in the memory.

c)Memory.cs
Declaration and defination of entity class Memory were implemented here. Memory entity represents the memory itself, containing several MemoryBlocks and also storing the information of it’s size. The class provides several methods to operate on the data of itself.

#### 2.Control class
a)PagingController.cs
Declaration and defination of control class PagingController were implemented here. The class entity itself has an array for hashing as well as many datatypes storing environment related datas. It controls whether a calculation will be done and do the LRU algorithm during the calculation. It also enables sorting to the memory as well as slowing down calculation for more detailed display. Furthermore, it calculates paging faults during calculation and can export the number of paging faults.

#### 3.Boundary classes
a)IceboxForm.cs
Part of declaration and defination of boundary class IceboxForm were implmented here. The class manages the display of the form and reacts to users interaction such as button-pressing and data inputting.

b)IceboxForm.Designer.cs
Part of declaration and defination of boundary class IceboxForm were implemented here. This part mainly deals with declaration of controls and basically defines some of the controls. Also the method of disposing is implemented here.

c)Program.cs
System automatically created codes to run the program. Some lines to abort the thread artificially started were added at the end.

#
### Application’s Display and Operations
On the leftmost side of the form are two buttons. One is marked as “Run”, the other as “Stop”. To the right of the buttons are three text boxes, each referring to a certain kind of parameter. When the three parameters are properly set, that is, the result of number of pages times number of instructions in each page is no more than 99999999 and the number of memory blocks is less than 33, the “Run” button will react to the clicking operation.

On the right side of the form are several rectangles representing memory blocks. Above them are a button marked as “Slowdown” and a label writing “Process:”. Below the rectangles is a label writing “Paging Fault Rate:”. The number of rectangles will be modify as soon as the “Run” button is pressed and the calculation is successfully carried on. Meanwhile, the “Process:” label will show the percentage of work done during calculation. The “Paging Fault Rate:” label, however, shows the real-time paging fault rate during and after calculation.

In each rectangle initially writes the number of the rectangle. After the “Run” button is pressed, the rectangle contains some lines writing the instructions the memory blocks now store. The memory blocks are placed order-ascendingly from left to right.

The “Slowdown” button controls the speed of calculation. When it is pressed, it will be marked as “Speedup” while the calculation will be slowed down to display the procedure in a more detail way. After it is pressed again when it’s marked as “Speedup”, it recovers the original speed of calculation and everything becomes as usual.

After the “Run” button is pressed, it will be marked as “Pause”, and input to the text boxes will become prohibited. When the calculation is done, it will be marked as “Run” once again. But before that, the button can be pressed to pause the calculation. When pressed at this time, the button will be changed to one marked as “Resume” who will resume calculation on pressing and then changed back to “Pause” button.

During the calculation, press the “Stop” button to permanently abort the calculation and re-enable input to the text boxes. The display on the right of the form will remain the same status as it is when the “Stop” button is pressed.

#
### Solution to the Problem
#### 1.Problem Analysis:
Finish a demo simulating the real request paging storage management. Use whatever method to implement it. Make a visualized presentation to show the result.


#### 2.Logic Solution:
a)First, by analysing the problem, we split the whole solution to three stages.

b)At stage one, we analyse the problem and find the use cases. And with the use cases find the classes to be implemented. Three kinds of classes are needed, that is, entity class, control class and boundary class. The entity classes represent each actor we have in the system, that is, page, memory block and memory. The control class to control the use cases which involves two or more actors, that is, paging control. The boundary classes to present the results to the user.

c)At stage two, we implement the classes. The design of the actors and their relations are very important. So we have to try several kinds of design and eventually decide on the most proper one. The rough design is already explained in stage one, we implement them in stage two.

d)At stage three, we finish all other work as icon making, process terminating, etc., making the product more efficient, and also, more user-friendly. Then we write the document about the project and the product.


#### 3.Technical Solution:
As we want to simulate the storage management, we must first create an object with a similar function to the real page and another one similar to the real memory. With them, we randomize some initial datas.

Then we use LRU algorithm to deal with the data. That is, when we go on to a new instruction, if the memory is not fully used, we just add the instruction to the memory and marked it with the time it is used most recently. When the memory is full, and the instruction is not in the memory, we find the one instruction that is most recently used and pop it out of the memory, adding the new instruction to the memory and marking it with the time it is added.

Everytime an instruction is popped out of the memory, a paging fault occurs. We record the number of times of which paging faults happen and display it graphically.

To display the form and information dynamically, we use multithreading and also create a thread to do the UI Control. This UI Control optimize elements in the graphic view with data other kind of classes provide object provides.

Because the rendering thread, id est, UIControl thread, is in an infinite loop, we must terminate all the process relevant to the program upon exiting the application.


#### 4.Detailed Solution:
THIS PART OF THE SOLUTION WILL BE PRESENTED IN CODES ATTACHED.
