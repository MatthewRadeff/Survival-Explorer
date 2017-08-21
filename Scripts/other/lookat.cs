using UnityEngine;
using System.Collections;

public class lookat : MonoBehaviour
{
    //https: //www.youtube.com/watch?v=-_k8Ob7ElUo

    public float m_speed = 3.0f;
    public GameObject m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;

    void Update()
    {
        if(m_target)
        {
            if (m_lastKnownPosition != m_target.transform.position)
            {
                m_lastKnownPosition = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            }


            if (transform.rotation != m_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, m_speed * Time.deltaTime);

            }

        }


    }




    bool SetTarget(GameObject target)
    {
        if(target)
        {
            return false;
        }

        m_target = target;

        return true;
    }


}
