// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/chicInput/input_action.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input_action : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input_action()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""input_action"",
    ""maps"": [
        {
            ""name"": ""PlayerMain"",
            ""id"": ""983bd5d9-fcee-4e73-9f8e-4000fe32b411"",
            ""actions"": [
                {
                    ""name"": ""Move1"",
                    ""type"": ""Value"",
                    ""id"": ""6efda27f-efb2-412d-a221-dc830e918e2d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""e3d766b4-01cb-41d1-bdc9-cf4b9af6b14e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""claim"",
                    ""type"": ""Button"",
                    ""id"": ""f4289f6b-6e8a-48d9-9c8f-34b20779cc51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""57e937e2-5acf-4f69-b673-56f7228c524a"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""move"",
                    ""id"": ""d8756fdb-73c6-42b9-a1fa-dee5d4b0bf10"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move1"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1de0ca16-b4fe-4f56-9e61-f26b16875cb4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06695b5b-a4ed-440a-b1be-047507bc269d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c7b1fc91-7477-4ba5-8363-9f9d649248a2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f31656f3-e83d-4058-8c45-5a560f7f649a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e37de4fa-e00b-4546-9088-ae66fb51494d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b69d3a14-9b6c-49f4-8b80-70b728d96678"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c05e3c1f-8864-4d6a-95db-05a2dd4214b9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""claim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMain
        m_PlayerMain = asset.FindActionMap("PlayerMain", throwIfNotFound: true);
        m_PlayerMain_Move1 = m_PlayerMain.FindAction("Move1", throwIfNotFound: true);
        m_PlayerMain_jump = m_PlayerMain.FindAction("jump", throwIfNotFound: true);
        m_PlayerMain_claim = m_PlayerMain.FindAction("claim", throwIfNotFound: true);
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

    // PlayerMain
    private readonly InputActionMap m_PlayerMain;
    private IPlayerMainActions m_PlayerMainActionsCallbackInterface;
    private readonly InputAction m_PlayerMain_Move1;
    private readonly InputAction m_PlayerMain_jump;
    private readonly InputAction m_PlayerMain_claim;
    public struct PlayerMainActions
    {
        private @Input_action m_Wrapper;
        public PlayerMainActions(@Input_action wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move1 => m_Wrapper.m_PlayerMain_Move1;
        public InputAction @jump => m_Wrapper.m_PlayerMain_jump;
        public InputAction @claim => m_Wrapper.m_PlayerMain_claim;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMainActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMainActions instance)
        {
            if (m_Wrapper.m_PlayerMainActionsCallbackInterface != null)
            {
                @Move1.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove1;
                @Move1.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove1;
                @Move1.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove1;
                @jump.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnJump;
                @claim.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnClaim;
                @claim.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnClaim;
                @claim.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnClaim;
            }
            m_Wrapper.m_PlayerMainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move1.started += instance.OnMove1;
                @Move1.performed += instance.OnMove1;
                @Move1.canceled += instance.OnMove1;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @claim.started += instance.OnClaim;
                @claim.performed += instance.OnClaim;
                @claim.canceled += instance.OnClaim;
            }
        }
    }
    public PlayerMainActions @PlayerMain => new PlayerMainActions(this);
    public interface IPlayerMainActions
    {
        void OnMove1(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnClaim(InputAction.CallbackContext context);
    }
}
