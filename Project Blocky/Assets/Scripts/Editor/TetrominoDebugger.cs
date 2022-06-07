using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TetrominoDebugger : EditorWindow
{
    private WaitlistBoard _waitlistBoard;
    
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
        var root = rootVisualElement;

        var buttonRoot = rootVisualElement.Q("TetrominoButtonsRoot");

        _tetrominoI = buttonRoot.Q<Button>("ButtonI");
        _tetrominoI.clicked += OnButtonIPressed;
        
        _tetrominoJ = buttonRoot.Q<Button>("ButtonJ");
        _tetrominoJ.clicked += OnButtonJPressed;
        
        _tetrominoL = buttonRoot.Q<Button>("ButtonL");
        _tetrominoL.clicked += OnButtonLPressed;
        
        _tetrominoO = buttonRoot.Q<Button>("ButtonO");
        _tetrominoO.clicked += OnButtonOPressed;
        
        _tetrominoS = buttonRoot.Q<Button>("ButtonS");
        _tetrominoS.clicked += OnButtonSPressed;
        
        _tetrominoT = buttonRoot.Q<Button>("ButtonT");
        _tetrominoT.clicked += OnButtonTPressed;
        
        _tetrominoZ = buttonRoot.Q<Button>("ButtonZ");
        _tetrominoZ.clicked += OnButtonZPressed;

        _eraseQueueButton = buttonRoot.Q<Button>("EraseQueue");
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
        _waitlistBoard.AddTetrominoOnWaitingList(_waitlistBoard.GetTetrominoData(0));
    }
    
    private void OnButtonJPressed()
    {
        _waitlistBoard.AddTetrominoOnWaitingList(_waitlistBoard.GetTetrominoData(1));
    }
    
    private void OnButtonLPressed()
    {
        _waitlistBoard.AddTetrominoOnWaitingList(_waitlistBoard.GetTetrominoData(2));
    }
    
    private void OnButtonOPressed()
    {
        _waitlistBoard.AddTetrominoOnWaitingList(_waitlistBoard.GetTetrominoData(3));
    }
    
    private void OnButtonSPressed()
    {
        _waitlistBoard.AddTetrominoOnWaitingList(_waitlistBoard.GetTetrominoData(4));
    }
    
    private void OnButtonTPressed()
    {
        _waitlistBoard.AddTetrominoOnWaitingList(_waitlistBoard.GetTetrominoData(5));
    }
    
    private void OnButtonZPressed()
    {
        _waitlistBoard.AddTetrominoOnWaitingList(_waitlistBoard.GetTetrominoData(6));
    }

    private void OnEraseQueue()
    {
        _waitlistBoard.EraseManualWaitlist();
    }
}