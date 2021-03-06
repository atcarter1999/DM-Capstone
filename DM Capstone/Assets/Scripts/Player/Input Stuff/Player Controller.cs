//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Player/Input Stuff/Player Controller.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controller"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""504bdb7f-f7e0-4e38-a696-31ccfba29480"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""78b99f65-2be6-4916-84ee-c213ad567055"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""5f670c8e-61e5-4e6d-82a5-2ee1d866a2b4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BaseAttack"",
                    ""type"": ""Button"",
                    ""id"": ""f70c6672-5501-46f2-bbf5-a5ff366a2203"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""56ce8a30-6abf-4b33-8f9c-9030fea58d46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""bf7ee169-37d0-4c3f-9b16-e82426f4c513"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Essence"",
                    ""type"": ""Button"",
                    ""id"": ""25d3e2a4-68e9-4027-a538-7c21ddfb9d0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""db2b5304-908e-42e7-8390-a8517b97f304"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2d02c5b8-9f4a-430e-9ccd-78d8830f16e5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27a841a0-dded-4cec-aba0-a1214123a235"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84ebce2e-2e4f-4133-897d-60c5c06627aa"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BaseAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52356c99-bccb-4c7d-a434-d78975d49c8a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6aaef32-3354-4d04-bc1e-1a4bffb40d1c"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5570a99-aec2-42ce-8722-5a025047b781"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Essence"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a871d9c-af84-49f2-b5ad-6b8b7d333cf0"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""bbf03f67-8bca-4e50-936a-4fd1d04ed248"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""22dae0eb-bbc2-46ea-bac5-e999be6aa9d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""5ba696b4-0bb3-44de-8383-d78033eceb05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6b158bb4-1a31-4a22-ad4c-1bdb562f5fb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""f4c62a88-dbf2-4b7a-9586-b4be4aaa3c35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""56daa0eb-09a1-49e0-ac4a-3a720a09009e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1dab5916-ad82-44e0-9224-d965c4c71c81"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1244d9c-2632-49f8-803c-bf2065b1ee1e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""734764ae-1b5c-4bfa-a55c-61af44a19349"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f226478-e998-407a-8cf1-bf92ab19a586"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d767a6bc-94a2-4b70-a435-d6402ab03e20"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""1dcbae4f-a5e7-4d86-9c3c-dc7856a0c554"",
            ""actions"": [
                {
                    ""name"": ""MenuUp"",
                    ""type"": ""Button"",
                    ""id"": ""ad3515a7-e055-47ec-8cc8-090990477c6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MenuDown"",
                    ""type"": ""Button"",
                    ""id"": ""a76fa5bd-c4d9-461b-ada9-6ba8bbc39403"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MenuLeft"",
                    ""type"": ""Button"",
                    ""id"": ""04b86b2d-193a-4a7c-aa5a-2dba1ff21861"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MenuRight"",
                    ""type"": ""Button"",
                    ""id"": ""8ed4e0c0-5414-4ac7-a99f-9dd61451ecf1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""7d43e584-b44d-4f6b-9dfd-3fef29311d2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""700e9c37-4f19-4539-ab0a-b4707d7a1b3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0774f13a-5fe0-44ed-8d1c-97991fef0249"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a2b3650-9dc6-4c18-b74f-6a269c5592d1"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46959e20-39db-467d-9907-61c706caa1cc"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09839ce7-43f5-4314-b5c2-2ba8347b4b4c"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e36267a-5d02-47ed-8e9e-863696b02c69"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""518e0118-9c6b-4a2c-9603-e89dba88bff8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_BaseAttack = m_Gameplay.FindAction("BaseAttack", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_Essence = m_Gameplay.FindAction("Essence", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_MoveLeft = m_Keyboard.FindAction("MoveLeft", throwIfNotFound: true);
        m_Keyboard_MoveRight = m_Keyboard.FindAction("MoveRight", throwIfNotFound: true);
        m_Keyboard_Jump = m_Keyboard.FindAction("Jump", throwIfNotFound: true);
        m_Keyboard_Dash = m_Keyboard.FindAction("Dash", throwIfNotFound: true);
        m_Keyboard_Pause = m_Keyboard.FindAction("Pause", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_MenuUp = m_Menu.FindAction("MenuUp", throwIfNotFound: true);
        m_Menu_MenuDown = m_Menu.FindAction("MenuDown", throwIfNotFound: true);
        m_Menu_MenuLeft = m_Menu.FindAction("MenuLeft", throwIfNotFound: true);
        m_Menu_MenuRight = m_Menu.FindAction("MenuRight", throwIfNotFound: true);
        m_Menu_Action = m_Menu.FindAction("Action", throwIfNotFound: true);
        m_Menu_Back = m_Menu.FindAction("Back", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_BaseAttack;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_Essence;
    private readonly InputAction m_Gameplay_Interact;
    public struct GameplayActions
    {
        private @PlayerController m_Wrapper;
        public GameplayActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @BaseAttack => m_Wrapper.m_Gameplay_BaseAttack;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @Essence => m_Wrapper.m_Gameplay_Essence;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @BaseAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBaseAttack;
                @BaseAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBaseAttack;
                @BaseAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBaseAttack;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Essence.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEssence;
                @Essence.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEssence;
                @Essence.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEssence;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @BaseAttack.started += instance.OnBaseAttack;
                @BaseAttack.performed += instance.OnBaseAttack;
                @BaseAttack.canceled += instance.OnBaseAttack;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Essence.started += instance.OnEssence;
                @Essence.performed += instance.OnEssence;
                @Essence.canceled += instance.OnEssence;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_MoveLeft;
    private readonly InputAction m_Keyboard_MoveRight;
    private readonly InputAction m_Keyboard_Jump;
    private readonly InputAction m_Keyboard_Dash;
    private readonly InputAction m_Keyboard_Pause;
    public struct KeyboardActions
    {
        private @PlayerController m_Wrapper;
        public KeyboardActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_Keyboard_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Keyboard_MoveRight;
        public InputAction @Jump => m_Wrapper.m_Keyboard_Jump;
        public InputAction @Dash => m_Wrapper.m_Keyboard_Dash;
        public InputAction @Pause => m_Wrapper.m_Keyboard_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMoveRight;
                @Jump.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDash;
                @Pause.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_MenuUp;
    private readonly InputAction m_Menu_MenuDown;
    private readonly InputAction m_Menu_MenuLeft;
    private readonly InputAction m_Menu_MenuRight;
    private readonly InputAction m_Menu_Action;
    private readonly InputAction m_Menu_Back;
    public struct MenuActions
    {
        private @PlayerController m_Wrapper;
        public MenuActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MenuUp => m_Wrapper.m_Menu_MenuUp;
        public InputAction @MenuDown => m_Wrapper.m_Menu_MenuDown;
        public InputAction @MenuLeft => m_Wrapper.m_Menu_MenuLeft;
        public InputAction @MenuRight => m_Wrapper.m_Menu_MenuRight;
        public InputAction @Action => m_Wrapper.m_Menu_Action;
        public InputAction @Back => m_Wrapper.m_Menu_Back;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @MenuUp.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuUp;
                @MenuUp.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuUp;
                @MenuUp.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuUp;
                @MenuDown.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuDown;
                @MenuDown.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuDown;
                @MenuDown.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuDown;
                @MenuLeft.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuLeft;
                @MenuLeft.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuLeft;
                @MenuLeft.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuLeft;
                @MenuRight.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuRight;
                @MenuRight.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuRight;
                @MenuRight.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuRight;
                @Action.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnAction;
                @Back.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MenuUp.started += instance.OnMenuUp;
                @MenuUp.performed += instance.OnMenuUp;
                @MenuUp.canceled += instance.OnMenuUp;
                @MenuDown.started += instance.OnMenuDown;
                @MenuDown.performed += instance.OnMenuDown;
                @MenuDown.canceled += instance.OnMenuDown;
                @MenuLeft.started += instance.OnMenuLeft;
                @MenuLeft.performed += instance.OnMenuLeft;
                @MenuLeft.canceled += instance.OnMenuLeft;
                @MenuRight.started += instance.OnMenuRight;
                @MenuRight.performed += instance.OnMenuRight;
                @MenuRight.canceled += instance.OnMenuRight;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnBaseAttack(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnEssence(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnMenuUp(InputAction.CallbackContext context);
        void OnMenuDown(InputAction.CallbackContext context);
        void OnMenuLeft(InputAction.CallbackContext context);
        void OnMenuRight(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
