//using system.collections;
//using system.collections.generic;
//using unityengine;

//public class birbspawner : monobehaviour
//{

//    //public gameobject birbprefab;
//    //private gameobject movingbirb;
//    public float speed;
//    private rigidbody2d rb;

//    // use this for initialization
//    void start()
//    {
//        //rb = getcomponent<rigidbody2d>();
//    }

//    // update is called once per frame
//    void update()
//    {
//        rb.addforce(transform.right * speed);
//        if (transform.position.x > 25.0f) death();
//    }

//    public void death()
//    {
//        destroy(gameobject);
//    }
//}
