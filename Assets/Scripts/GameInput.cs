using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set;  }

    private const string GAMEINPUT_BINDINGS = "GameInputBindings";
    public event EventHandler OnInteractAction;
    public event EventHandler OnOperateAction;
    public event EventHandler OnPauseAction;//暂停

    [SerializeField] private GameControl gameControl;// 游戏控制
    public enum BindingType
    {
        Up,
        Down,
        Left,
        Right,
        Operation,
        Interact,
        Pause
    }
    private void Awake()
    {
        Instance = this;
        gameControl = new GameControl();//创建新GameControl类（非组件）
        if(PlayerPrefs.HasKey(GAMEINPUT_BINDINGS))//判断是否有保存信息
        gameControl.LoadBindingOverridesFromJson(PlayerPrefs.GetString(GAMEINPUT_BINDINGS));//读取保存信息
        
        gameControl.Player.Enable();//唤醒Player的Actions Map

        gameControl.Player.Interact.performed += Interact_Performed;//配对应方法Interact_Performed4(订阅发布模式)
        gameControl.Player.Operate.performed += Operate_Performed;//配对应方法Interact_Performed4(订阅发布模式)
        gameControl.Player.Pause.performed += Pause_performed;
    }
    public string GetBindingTypeString(BindingType bindingType)
    {
        switch (bindingType)
        {
            case BindingType.Up:
                return gameControl.Player.Move.bindings[1].ToDisplayString();
            case BindingType.Down:
                return gameControl.Player.Move.bindings[2].ToDisplayString();
            case BindingType.Left:
                return gameControl.Player.Move.bindings[3].ToDisplayString();
            case BindingType.Right:
                return gameControl.Player.Move.bindings[4].ToDisplayString();
            case BindingType.Operation:
                return gameControl.Player.Operate.bindings[0].ToDisplayString();
            case BindingType.Interact:
                return gameControl.Player.Interact.bindings[0].ToDisplayString();
            case BindingType.Pause:
                return gameControl.Player.Pause.bindings[0].ToDisplayString();
            default:
                return null;
        }
    }

    public void ReBinding(BindingType bindingType,Action onComplete)
    {
        gameControl.Player.Disable();//先禁用（否则无法重新绑定）
        InputAction inputAction=null;//绑定的类型
        int index=0;//索引
        switch (bindingType)
        {
            case BindingType.Up:
                index = 1;
                inputAction = gameControl.Player.Move;
                break;
            case BindingType.Down:
                index = 2;
                inputAction = gameControl.Player.Move;
                break;
            case BindingType.Left:
                index = 3;
                inputAction = gameControl.Player.Move;
                break;
            case BindingType.Right:
                index = 4;
                inputAction = gameControl.Player.Move;
                break;
            case BindingType.Operation:
                index = 0;
                inputAction = gameControl.Player.Operate;
                break;
            case BindingType.Interact:
                index = 0;
                inputAction = gameControl.Player.Interact;
                break;
            case BindingType.Pause:
                index = 0;
                inputAction = gameControl.Player.Pause;
                break;
        default:
                break;
        }
        inputAction.PerformInteractiveRebinding(index).OnComplete(callback =>
        {
            callback.Dispose();//资源释放
            gameControl.Player.Enable();//重新启用GameContral
            onComplete?.Invoke();

            //gameControl.SaveBindingOverridesAsJson();//返回保存信息并保存为json
            PlayerPrefs.SetString(GAMEINPUT_BINDINGS, gameControl.SaveBindingOverridesAsJson());
            PlayerPrefs.Save();//数据保存到本地
        }).Start();
    }
public void OnDistory()
    {//释放对应资源
        gameControl.Player.Interact.performed -= Interact_Performed;//
        gameControl.Player.Operate.performed -= Operate_Performed;//
        gameControl.Player.Pause.performed -= Pause_performed;//
        gameControl.Dispose();//释放资源
    }
    private void Pause_performed(InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);//触发事件
    }

    private void Operate_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);//OnInteractAction可能为空，不为空则执行
    }

    public Vector3 GameInputDirectionNormalized()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");//获取左右操作
        //float vertical = Input.GetAxisRaw("Vertical");//获取上下
        Vector2 inputVector2 = gameControl.Player.Move.ReadValue<Vector2>();

        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);//设置方向

        direction = direction.normalized;//单位化向量
        return direction;
    }
}
