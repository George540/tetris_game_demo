using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TetrominoDebugger : EditorWindow
{
    private WaitlistBoard _waitlistBoard;

    private VisualElement _root;
    private VisualElement _buttonRoot;
    private Button _tetrominoI;
    private Button _tetrominoJ;
    private Button _tetrominoL;
    private Button _tetrominoO;
    private Button _tetrominoS;
    private Button _tetrominoT;
    private Button _tetrominoZ;
    private Button _eraseQueueButton;


    [MenuItem("Debug/Tetromino Debugger _%#D")]
    public static void ShowWindow()
    {
        var window = GetWindow<TetrominoDebugger>();
        window.titleContent = new GUIContent("TetrominoDebugger");
        window.minSize = new Vector2(350, 350);
        window.Show();
    }

    public void OnEnable()
    {
        InitializeUxmlTemplate();
        
        _waitlistBoard = FindObjectOfType<WaitlistBoard>();
        
        // Each editor window contains a root VisualElement object
        _root = rootVisualElement;

        _buttonRoot = _root.Q("TetrominoButtonsRoot");

        _tetrominoI = _buttonRoot.Q<Button>("ButtonI");
        _tetrominoI.clicked += OnButtonIPressed;
        
        _tetrominoJ = _buttonRoot.Q<Button>("ButtonJ");
        _tetrominoJ.clicked += OnButtonJPressed;
        
        _tetrominoL = _buttonRoot.Q<Button>("ButtonL");
        _tetrominoL.clicked += OnButtonLPressed;
        
        _tetrominoO = _buttonRoot.Q<Button>("ButtonO");
        _tetrominoO.clicked += OnButtonOPressed;
        
        _tetrominoS = _buttonRoot.Q<Button>("ButtonS");
        _tetrominoS.clicked += OnButtonSPressed;
        
        _tetrominoT = _buttonRoot.Q<Button>("ButtonT");
        _tetrominoT.clicked += OnButtonTPressed;
        
        _tetrominoZ = _buttonRoot.Q<Button>("ButtonZ");
        _tetrominoZ.clicked += OnButtonZPressed;

        _eraseQueueButton = _buttonRoot.Q<Button>("EraseQueue");
        _eraseQueueButton.clicked += OnEraseQueue;


        /*// VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Editor/TetrominoDebugger.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/Editor/TetrominoDebugger.uss");
        VisualElement labelWithStyle = new Label("Hello World! With Style");
        labelWithStyle.styleSheets.Add(styleSheet);
        root.Add(labelWithStyle);*/
    }
    
    private void InitializeUxmlTemplate()
    {
        rootVisualElement.Clear();
        var template = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Editor/TetrominoDebugger.uxml");
        template.CloneTree(rootVisualElement);
    }

    private void OnButtonIPressed()
    {
        var data = _waitlistBoard.GetTetrominoData(0);
        _waitlistBoard.AddTetrominoOnWaitingList(data);
    }
    
    private void OnButtonJPressed()
    {
        var data = _waitlistBoard.GetTetrominoData(1);
        _waitlistBoard.AddTetrominoOnWaitingList(data);
    }
    
    private void OnButtonLPressed()
    {
        var data = _waitlistBoard.GetTetrominoData(2);
        _waitlistBoard.AddTetrominoOnWaitingList(data);
    }
    
    private void OnButtonOPressed()
    {
        var data = _waitlistBoard.GetTetrominoData(3);
        _waitlistBoard.AddTetrominoOnWaitingList(data);
    }
    
    private void OnButtonSPressed()
    {
        var data = _waitlistBoard.GetTetrominoData(4);
        _waitlistBoard.AddTetrominoOnWaitingList(data);
    }
    
    private void OnButtonTPressed()
    {
        var data = _waitlistBoard.GetTetrominoData(5);
        _waitlistBoard.AddTetrominoOnWaitingList(data);
    }
    
    private void OnButtonZPressed()
    {
        var data = _waitlistBoard.GetTetrominoData(6);
        _waitlistBoard.AddTetrominoOnWaitingList(data);
    }

    private void OnEraseQueue()
    {
        _waitlistBoard.EraseManualWaitlist();
    }
}