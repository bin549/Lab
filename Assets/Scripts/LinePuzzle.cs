using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LinePuzzleRenderer))]
public class LinePuzzle : MonoBehaviour
{
    [SerializeField] private bool m_debug = false;
    [SerializeField] private float m_inputSpeed = 0.03f;
    [SerializeField] private float m_cornerTolerance = 0.3f;
    [SerializeField] private PuzzleData mPuzzleData = null;

    private LinePuzzleRenderer mRenderer = null;
    private List<PuzzleNode> mPlayerLine = new List<PuzzleNode>();
    private bool mFocused = false;
    private bool mCompleted = false;
    private Vector2 mCursorPos = Vector2.zero;
    private bool mValid = true;
    private PlayerController mControllerRef = null;

    private void Awake()
    {
        mValid = true;
        if (mPuzzleData == null)
        {
            mValid = false;
            Debug.LogError("No puzzle data found on object " + transform.name);
            Destroy(gameObject);
            return;
        }

        if (!mPuzzleData.Init())
        {
            mValid = false;
            Debug.LogError("No valid puzzle data found on object " + transform.name);
            Destroy(gameObject);
            return;
        }

        mRenderer = GetComponent<LinePuzzleRenderer>();
        if (mRenderer == null)
        {
            mValid = false;
            Debug.LogError("No puzzle renderer found on object " + transform.name);
            Destroy(gameObject);
            return;
        }

        mRenderer.Init(mPuzzleData);

        if (m_debug)
        {
            mRenderer.DrawDebugBorder(mPuzzleData.GetBounds(), Random.ColorHSV());
        }
    }

    public void Update()
    {
        if (!mFocused)
        {
            return;
        }
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * m_inputSpeed;
        if (input.magnitude == 0.0f)
        {
            return;
        }

        PuzzleNode currentNode = mPlayerLine[mPlayerLine.Count - 1];
        List<PuzzleNode> connectedNodes = mPuzzleData.NodeData.GetConnectedNodes(currentNode);

        float len = Vector2.Distance(mCursorPos + input, currentNode.pos);

        if (len <= 0.0f)
        {
            return;
        }

        Vector2 checkVal = mCursorPos - currentNode.pos;
        if (len <= m_cornerTolerance)
        {
            checkVal = input;
        }

        System.Func<PuzzleNode, float> OrderAngle = x => Vector2.Angle(checkVal, x.pos - currentNode.pos);
        PuzzleNode targetNode = connectedNodes.OrderBy(OrderAngle).First();

        Vector2 targetDir = (targetNode.pos - currentNode.pos);


        bool reversing = false;
        if (mPlayerLine.Count > 1)
        {
            Vector2 a = currentNode.pos;
            Vector2 b = mPlayerLine[mPlayerLine.Count - 2].pos;
            reversing = (b - a).normalized == targetDir.normalized;
        }

        if (mPuzzleData.NodeData.GetConnectedNodes(currentNode).Count <= 1)
        {
            reversing = true;
        }

        if (reversing)
        {
            if (len < m_cornerTolerance)
            {
                mCursorPos = currentNode.pos;
                mPlayerLine.RemoveAt(mPlayerLine.Count - 1);
                mRenderer.UpdatePlayerLine(mPlayerLine);
                mRenderer.MoveCursor(mPlayerLine.Last().pos, mCursorPos);
            }
            return;
        }

        mCursorPos = currentNode.pos + Vector2.ClampMagnitude(targetDir, len);
        mRenderer.MoveCursor(currentNode.pos, mCursorPos);
        mRenderer.ShowDynamicLine(true);

        if (mCursorPos == targetNode.pos)
        {
            if (mPlayerLine.Contains(targetNode)) return; //Disallow overlapping
            HitCorner(targetNode);
        }
    }

    public void Focus(PlayerController controller)
    {
        if (!mValid || mFocused)
        {
            return;
        }
        mControllerRef = controller;
        mControllerRef.SetInputEnabled(false);
        this.ResetPuzzle();
        mFocused = true;
    }

    public void UnFocuse()
    {
        if (!this.mFocused)
        {
            return;
        }
        if (this.mControllerRef)
        {
            mControllerRef.SetInputEnabled(true);
        }
        mControllerRef = null;
        mFocused = false;
    }

    public void HitCorner(PuzzleNode node)
    {
        if (!mValid){
            return;
        }
        mPlayerLine.Add(node);
        if (node.type == NodeType.End) 
        {
            if (mPuzzleData.Test(mPlayerLine, out List<List<PuzzleNode>> borders))
            {
                if (m_debug)
                {
                    this.DrawDebugBorders(borders);
                }
                CompletePuzzle();
            }
            else
            {
                if (m_debug)
                {
                    this.DrawDebugBorders(borders);
                }
                ResetPuzzle();
            }
        }

        mRenderer.UpdatePlayerLine(mPlayerLine);
    }

    public void CompletePuzzle()
    {
        Debug.Log("Puzzle Completed");
        mCompleted = true;
        mRenderer.ShowDynamicLine(false);
        UnFocuse();
    }

    public void ResetPuzzle()
    {
        mCursorPos = mPuzzleData.NodeData.GetStartNode().pos;
        mCompleted = false;
        mPlayerLine.Clear();
        mPlayerLine.Add(mPuzzleData.NodeData.GetStartNode());
        mRenderer.UpdatePlayerLine(mPlayerLine);
        mRenderer.ShowDynamicLine(false);
        UnFocuse();
    }

    public bool IsCompleted()
    {
        return mCompleted;
    }

    public void DrawDebugBorders(List<List<PuzzleNode>> borders)
    {
        mRenderer.ClearDebugBorders();
        if (borders == null) return;
        for (int i = 0; i < borders.Count; ++i)
        {
            mRenderer.DrawDebugBorder(borders[i], Random.ColorHSV());
        }

        Debug.Log(string.Format("Drawing {0} debug borders", borders.Count));
    }
}