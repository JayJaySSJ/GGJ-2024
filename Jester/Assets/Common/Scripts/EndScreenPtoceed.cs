//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Common/EndScreenPtoceed.inputactions
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

public partial class @EndScreenPtoceed: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @EndScreenPtoceed()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EndScreenPtoceed"",
    ""maps"": [
        {
            ""name"": ""Confirm"",
            ""id"": ""abdafd76-c701-4929-9838-c659c6ecd186"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""5057af07-923f-4472-b090-8a8ab13b3f90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e21b11c2-faf4-4d20-8325-8de67a381eb0"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68220f51-c06b-4e65-8ab5-37f80394a773"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c108616-fcdb-462e-826b-f34cbd8c450c"",
                    ""path"": ""<HID::USB Gamepad >/button9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c03cf76-1d1b-4b1a-b7b1-0b36a4ac90ec"",
                    ""path"": ""<HID::USB Gamepad >/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Confirm
        m_Confirm = asset.FindActionMap("Confirm", throwIfNotFound: true);
        m_Confirm_Confirm = m_Confirm.FindAction("Confirm", throwIfNotFound: true);
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

    // Confirm
    private readonly InputActionMap m_Confirm;
    private List<IConfirmActions> m_ConfirmActionsCallbackInterfaces = new List<IConfirmActions>();
    private readonly InputAction m_Confirm_Confirm;
    public struct ConfirmActions
    {
        private @EndScreenPtoceed m_Wrapper;
        public ConfirmActions(@EndScreenPtoceed wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_Confirm_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_Confirm; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConfirmActions set) { return set.Get(); }
        public void AddCallbacks(IConfirmActions instance)
        {
            if (instance == null || m_Wrapper.m_ConfirmActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ConfirmActionsCallbackInterfaces.Add(instance);
            @Confirm.started += instance.OnConfirm;
            @Confirm.performed += instance.OnConfirm;
            @Confirm.canceled += instance.OnConfirm;
        }

        private void UnregisterCallbacks(IConfirmActions instance)
        {
            @Confirm.started -= instance.OnConfirm;
            @Confirm.performed -= instance.OnConfirm;
            @Confirm.canceled -= instance.OnConfirm;
        }

        public void RemoveCallbacks(IConfirmActions instance)
        {
            if (m_Wrapper.m_ConfirmActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IConfirmActions instance)
        {
            foreach (var item in m_Wrapper.m_ConfirmActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ConfirmActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ConfirmActions @Confirm => new ConfirmActions(this);
    public interface IConfirmActions
    {
        void OnConfirm(InputAction.CallbackContext context);
    }
}
