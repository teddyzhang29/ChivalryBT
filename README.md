# Setup

1. Import **ChivalryBT.dll** and **ChivalryBTEditor.dll** to Unity3d Project under Folder `Assets/Plugins` (Create if none).  
    ![Figure1](https://github.com/teddyzhang29/ChivalryBT/blob/master/Images/setup1.png)
2. Select ChivalryBTEditor.dll, set the platform to Editor only, otherwise you can **NOT** build project.  
    ![Figure2](https://github.com/teddyzhang29/ChivalryBT/blob/master/Images/setup2.png)

# Usage

After easy setup, now you can use ChivalryBT. Click [here](https://en.wikipedia.org/wiki/Behavior_tree) to know what is Behaviour Tree.

## Basic
1. Click menu **GameObject->Behaviour Tree** to create a template.
2. Unfold ChivalryBT.dll and you'll see all nodes.
3. Create an empty GameObject, then drag it under **Sequence** node which is just automatically created in step 1. Drag **Log** node to the empty GameObject. If success, the GameObject you just create will auto renamed as "Log".
4. Pick **Log** node and set argument as "start".
5. In the same way, create **Wait**(set argument as "1") and another **Log**(set argument as "finish") below. Now, there are 3 nodes under **Sequence**.  
    ![Figure3](https://github.com/teddyzhang29/ChivalryBT/blob/master/Images/basicusage1.png)
6. Play game and see console's output.


**Note**: One GameObject can attach **one** node at most.

## Custom Node

There are three types node in Behaivour Tree: Action, Compositer, Decorator.


```
public class YOUR_ACTION : Action
{
    protected override void OnResetData()
    {
        base.OnResetData();
        //execute before restart this action
    }

    protected override ActionState OnExecute()
    {
        //code here.
        //ActionState has three values:Success,Failed,Running.
        //if you execute a long-time action, such as Walk, you should return Running when not reach destination.
        return ActionState.Success;
    }
}
```

## Variable

Variable support a way to share value in nodes. ChivalryBT gives some built-in variables such as Bool, Int, Float, etc. To use variables, refer steps below.

1. Create a empty GameObject to hold variable, put it anywhere you like(under **Variables** GameObject is recommended.).
2. Attach **StringVariable** component on the GameObject and set variable's value.
3. Pick **Log** node, check the toggle right of the argument **Log**.  
    ![Figure4](https://github.com/teddyzhang29/ChivalryBT/blob/master/Images/variable1.png)


now, **Log** node's argument use the value of the StringVarialbe. If there's another node to change the value of that StringVariable, **Log** changes too.

# Debug

ChivalryBT will set state of every executed node as prefix of their names.  
    ![Figure5](https://github.com/teddyzhang29/ChivalryBT/blob/master/Images/debug1.png)

* S = Success
* F = Failed
* R = Running