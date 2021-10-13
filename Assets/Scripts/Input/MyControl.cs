// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/MyControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyControl"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""32cb07ab-baab-4776-be40-562bba2eb0ce"",
            ""actions"": [
                {
                    ""name"": ""forward"",
                    ""type"": ""Button"",
                    ""id"": ""8529898d-e8c8-4177-bb2a-2ce4d306268a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""backward"",
                    ""type"": ""Button"",
                    ""id"": ""50989a87-4f48-4e20-859c-86c1b6254007"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""left"",
                    ""type"": ""Button"",
                    ""id"": ""d4c11815-b6e3-4046-817a-e63e0b8303e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""right"",
                    ""type"": ""Button"",
                    ""id"": ""1ef2e0d6-d812-46a1-ae1c-acbcf62c6203"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""db9ce071-72c9-4737-9832-5fb2ff4727a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b4ad6fcd-1446-4197-adca-35ccbd3cd007"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""forward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bf9a35bf-8b07-46fb-924d-bd3d19e03c4f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""830011ca-bcd7-4722-a223-c22cbb3beda2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""075d43bb-9cca-4d46-9aa9-3fce4f87180f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""backward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e606b357-655b-47fa-bd67-1868d44213dd"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8197a89d-4e05-4da9-bfd7-46b6af40894e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""89f84410-3e44-4fe9-8ff7-311e5744b2d3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f3258a9c-2498-4983-a7c8-bbd8edb1b1b8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7e073d7d-f42c-4b18-b072-0c86e38a65ae"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""9a1c8306-5256-46a6-88e0-b8f899c2aeb6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e0baa814-1ae1-4f7b-b39d-012437d9e5b2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4e9750f2-c292-451b-9105-5238cb6531c6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d4187f2f-8146-4abf-bdb0-9a561324c29b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_forward = m_Player.FindAction("forward", throwIfNotFound: true);
        m_Player_backward = m_Player.FindAction("backward", throwIfNotFound: true);
        m_Player_left = m_Player.FindAction("left", throwIfNotFound: true);
        m_Player_right = m_Player.FindAction("right", throwIfNotFound: true);
        m_Player_jump = m_Player.FindAction("jump", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_forward;
    private readonly InputAction m_Player_backward;
    private readonly InputAction m_Player_left;
    private readonly InputAction m_Player_right;
    private readonly InputAction m_Player_jump;
    public struct PlayerActions
    {
        private @MyControl m_Wrapper;
        public PlayerActions(@MyControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @forward => m_Wrapper.m_Player_forward;
        public InputAction @backward => m_Wrapper.m_Player_backward;
        public InputAction @left => m_Wrapper.m_Player_left;
        public InputAction @right => m_Wrapper.m_Player_right;
        public InputAction @jump => m_Wrapper.m_Player_jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @backward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @backward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @backward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @forward.started += instance.OnForward;
                @forward.performed += instance.OnForward;
                @forward.canceled += instance.OnForward;
                @backward.started += instance.OnBackward;
                @backward.performed += instance.OnBackward;
                @backward.canceled += instance.OnBackward;
                @left.started += instance.OnLeft;
                @left.performed += instance.OnLeft;
                @left.canceled += instance.OnLeft;
                @right.started += instance.OnRight;
                @right.performed += instance.OnRight;
                @right.canceled += instance.OnRight;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
