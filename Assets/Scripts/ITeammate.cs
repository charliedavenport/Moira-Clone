using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeammate  {

    float Health { get; }

    void AddHealth(float hp);
	
}
