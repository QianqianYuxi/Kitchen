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
    public event EventHandler OnPauseAction;//��ͣ

    [SerializeField] private GameControl gameControl;// ��Ϸ����
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
        gameControl = new GameControl();//������GameControl�ࣨ�������
        if(PlayerPrefs.HasKey(GAMEINPUT_BINDINGS))//�ж��Ƿ��б�����Ϣ
        gameControl.LoadBindingOverridesFromJson(PlayerPrefs.GetString(GAMEINPUT_BINDINGS));//��ȡ������Ϣ
        
        gameControl.Player.Enable();//����Player��Actions Map

        gameControl.Player.Interact.performed += Interact_Performed;//���Ӧ����Interact_Performed4(���ķ���ģʽ)
        gameControl.Player.Operate.performed += Operate_Performed;//���Ӧ����Interact_Performed4(���ķ���ģʽ)
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
        gameControl.Player.Disable();//�Ƚ��ã������޷����°󶨣�
        InputAction inputAction=null;//�󶨵�����
        int index=0;//����
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
            callback.Dispose();//��Դ�ͷ�
            gameControl.Player.Enable();//��������GameContral
            onComplete?.Invoke();

            //gameControl.SaveBindingOverridesAsJson();//���ر�����Ϣ������Ϊjson
            PlayerPrefs.SetString(GAMEINPUT_BINDINGS, gameControl.SaveBindingOverridesAsJson());
            PlayerPrefs.Save();//���ݱ��浽����
        }).Start();
    }
public void OnDistory()
    {//�ͷŶ�Ӧ��Դ
        gameControl.Player.Interact.performed -= Interact_Performed;//
        gameControl.Player.Operate.performed -= Operate_Performed;//
        gameControl.Player.Pause.performed -= Pause_performed;//
        gameControl.Dispose();//�ͷ���Դ
    }
    private void Pause_performed(InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);//�����¼�
    }

    private void Operate_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);//OnInteractAction����Ϊ�գ���Ϊ����ִ��
    }

    public Vector3 GameInputDirectionNormalized()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");//��ȡ���Ҳ���
        //float vertical = Input.GetAxisRaw("Vertical");//��ȡ����
        Vector2 inputVector2 = gameControl.Player.Move.ReadValue<Vector2>();

        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);//���÷���

        direction = direction.normalized;//��λ������
        return direction;
    }
}
