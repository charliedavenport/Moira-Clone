using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility  {

    List<GameObject> Targets { get; }

    Collider collider { get; }

    
}
