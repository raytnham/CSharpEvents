An event is a message sent by an object to signal the occurrence of an action. In object-oriented programming, <strong>Events</strong> allow a class or an object to be notified when something interesting occurs. An event can be generated or triggered by the system, the user or in other ways. The entity that initiates the notifications is called the <strong><em>publisher</em></strong> while the entity that receives the notifications is called a <strong><em>subscriber</em></strong>. Some examples of events could be a button clicked, users being idle, device orientation changed, etc. In this post, we will discuss how to define and utilize custom events in C# programming language.
<!--more-->

<strong>DEFINING AN EVENT</strong>

The concept of events in C# is based on <a href="https://raydeveloperonline.com/2018/02/19/cs-delegates/" rel="noopener" target="_blank">delegates</a>. We will use delegate syntax to define an <strong>event handler</strong>. An <strong>event handler</strong> is a delegate type that will provide responses whenever an event is triggered. By having the event handler to be a delegate type, the developer can easily assign a method/function to it using chained delegates.
<div class="highlight"><pre><span></span><span class="c1">// Declare an event handler using delegate syntax.</span>
<span class="k">public</span> <span class="k">delegate</span> <span class="k">void</span> <span class="nf">MyEventHandler</span><span class="p">(</span><span class="kt">decimal</span> <span class="n">theValue</span><span class="p">);</span>
</pre></div>
So, we have defined an event handler named <strong>MyEventHandler</strong> and it accepts a decimal value. This event handler is of a delegate type. That is, we can assign any function/method to the references that have this type.
Next, to declare an event of MyEventHandler type, we use the <strong>event</strong> keyword.
<div class="highlight"><pre><span></span><span class="c1">// Declare an event.</span>
<span class="k">public</span> <span class="k">event</span> <span class="n">MyEventHandler</span> <span class="n">myEventName</span><span class="p">;</span>
</pre></div>

<strong>EVENT USAGE</strong>

Now, putting everything we discussed above together, we have:
<div class="highlight"><pre><span></span><span class="c1">// Define a event handler.</span>
<span class="k">public</span> <span class="k">delegate</span> <span class="k">void</span> <span class="nf">BalanceEventHandler</span><span class="p">(</span><span class="kt">decimal</span> <span class="n">newValue</span><span class="p">);</span>
<span class="k">class</span> <span class="nc">PiggyBank</span>
<span class="p">{</span>
    <span class="k">private</span> <span class="kt">decimal</span> <span class="n">bankBalance</span><span class="p">;</span>
    <span class="c1">// Delare an event.</span>
    <span class="k">public</span> <span class="k">event</span> <span class="n">BalanceEventHandler</span> <span class="n">balanceChanged</span><span class="p">;</span>
    <span class="k">public</span> <span class="kt">decimal</span> <span class="n">theBalance</span>
    <span class="p">{</span>
        <span class="k">set</span>
        <span class="p">{</span>
            <span class="n">bankBalance</span> <span class="p">=</span> <span class="k">value</span><span class="p">;</span>
            <span class="c1">// The event will be trigger whenver bankBalance is being changed.</span>
            <span class="n">balanceChanged</span><span class="p">(</span><span class="k">value</span><span class="p">);</span>
        <span class="p">}</span>
        <span class="k">get</span>
        <span class="p">{</span>
            <span class="k">return</span> <span class="n">bankBalance</span><span class="p">;</span>
        <span class="p">}</span>
    <span class="p">}</span>
<span class="p">}</span>
</pre></div>
Here we have a <strong>PiggyBank</strong> class consisting of one member variable named <strong>bankBalance</strong> and an event named <strong>balanceChanged</strong>. Within the setter of <strong>bankBalance</strong>, the event <strong>balanceChanged</strong> is triggered. However, the implementation of that event has not been defined. We'll do that by define a class named <strong>BalanceLogger</strong>.
<div class="highlight"><pre><span></span><span class="c1">// Event implementation: to log the amount being set to the PiggyBank class.</span>
<span class="k">class</span> <span class="nc">BalanceLogger</span>
<span class="p">{</span>
    <span class="k">public</span> <span class="k">void</span> <span class="nf">balanceLog</span><span class="p">(</span><span class="kt">decimal</span> <span class="n">amount</span><span class="p">)</span>
    <span class="p">{</span>
        <span class="n">Console</span><span class="p">.</span><span class="n">WriteLine</span><span class="p">(</span><span class="s">&quot;The balance amount is {0}&quot;</span><span class="p">,</span> <span class="n">amount</span><span class="p">);</span>
    <span class="p">}</span>
<span class="p">}</span>
</pre></div>
The <strong>BalanceLogger</strong> class contains one method that writes the value it recevices to the console log. The next thing to do is to bind this implementation to our event which has been delared above.
<div class="highlight"><pre><span></span><span class="c1">// Initiate the PiggyBank and BalanceLogger classes.</span>
<span class="n">PiggyBank</span> <span class="n">bank</span> <span class="p">=</span> <span class="k">new</span> <span class="n">PiggyBank</span><span class="p">();</span>
<span class="n">BalanceLogger</span> <span class="n">logger</span> <span class="p">=</span> <span class="k">new</span> <span class="n">BalanceLogger</span><span class="p">();</span>
<span class="c1">// Bind the implemation of blanceLog method to the event balanceChanged.</span>
<span class="n">bank</span><span class="p">.</span><span class="n">balanceChanged</span> <span class="p">+=</span> <span class="n">logger</span><span class="p">.</span><span class="n">balanceLog</span><span class="p">;</span>
<span class="c1">// Try to set the value of bankBalance to 1000.</span>
<span class="n">bank</span><span class="p">.</span><span class="n">bankBlance</span> <span class="p">=</span> <span class="m">1000</span><span class="p">;</span>
</pre></div>
Executing the code block above will write to the console log:
<div class="highlight"><pre><span></span>$ The balance amount is 1000
</pre></div>
As we can see, the event <strong>balanceChanged</strong> has been triggered when we set the value of <strong>bankBalance</strong> to 1000.

<strong>REFERENCES</strong>
<a href="https://www.lynda.com/C-tutorials/C-Delegates-Events-Lambdas/370499-2.html">Lynda.com - C#: Delegates, Events and Lambdas - by Joe Marini</a>
<a href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/" rel="noopener" target="_blank">Microsoft - Events (C# Programming Guide)</a>




