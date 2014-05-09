using UnityEngine;
using System.Collections;

/// <summary>
/// 滚轮切换第一第三视角脚本
/// 完成者:
/// 完成时间:
/// </summary>
public class Camera_New : MonoBehaviour
{
    #region 成员变量_共有

    /// <summary>
    /// 镜头目标,这里拖入镜头
    /// </summary>
    public Transform m_Camera;

    /// <summary>
    /// 镜头离目标的距离
    /// </summary>
    public float m_Dis = 30.0f;

    /// <summary>
    /// 最大镜头可视距离
    /// </summary>
    public float m_MaxDis = 50.0f;

    /// <summary>
    /// 镜头旋转速度
    /// </summary>
    public float m_RotateFactor = 10.0f;

    /// <summary>
    /// 鼠标滚轮拉近拉远速度
    /// </summary>
    public float m_ScrollFactor = 10.0f;

    /// <summary>
    /// 镜头水平角度
    /// </summary>
    public float m_HorizontalAngle = 45;

    /// <summary>
    /// 镜头垂直角度
    /// </summary>
    public float m_VerticalAngle = 0;

    #endregion

    #region 成员变量_私有

    /// <summary>
      /// </summary>
    private Transform m_Camera_Transform;

    #endregion

    /// <summary>
    /// 初始化函数
    /// </summary>
    void Start()
    {
        // 这句话将你单位变化,赋值给transform;
        m_Camera_Transform = transform;
    }

    /// <summary>
    /// 每帧循环
    /// </summary>
    void Update()
    {
        // 接受鼠标滚轮事件
        float _mouse_input = Input.GetAxis("Mouse ScrollWheel");

        // 设置相机距离
        m_Dis -= _mouse_input * m_ScrollFactor;

        // 如果镜头距离小于0,那么就设置成0保证不为负数
        if (m_Dis < 0)
        {
            m_Dis = 0;
        }
        // 限制镜头最远距离
        else if (m_Dis > m_MaxDis)
        {
            m_Dis = m_MaxDis;
        }

        // 判断鼠标左右键是否输入
        if (Input.GetMouseButton(0) ||
            Input.GetMouseButton(1))
        {
            // 光标将自动隐藏，居中于视图并且不会离开这个视图。
            Screen.lockCursor = true;

            // 获取鼠标移动相对于上个位置的相对度量值
            m_HorizontalAngle += Input.GetAxis("Mouse X") * m_RotateFactor;
            m_VerticalAngle += Input.GetAxis("Mouse Y") * m_RotateFactor;

            if (Input.GetMouseButtonUp(1))
            {
                //如果是鼠标右键移动，则旋转人物在水平面上与镜头方向一致
                m_Camera.rotation = Quaternion.Euler(0, m_HorizontalAngle, 0);
            }
        }
        else
        {
            // 取消光标隐藏
            Screen.lockCursor = false;
        }

        // 调整镜头位置
        m_Camera_Transform.position = m_Camera.position + Quaternion.Euler(-m_VerticalAngle, m_HorizontalAngle, 0) * Vector3.back * m_Dis;
        m_Camera_Transform.rotation = Quaternion.Euler(-m_VerticalAngle, m_HorizontalAngle, 0);

        // Debug.Log("Test======UpData");
    }
}