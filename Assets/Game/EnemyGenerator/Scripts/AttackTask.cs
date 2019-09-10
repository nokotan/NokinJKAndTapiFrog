using System.Linq;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "CommandTask/CreateAttackTask")]
public class AttackTask : CommandTask
{
    [SerializeField] CommandTable table;
    [SerializeField] float waitTime = 1.0f;

    public override IEnumerator DoCommand(string[] args)
    {
        string enemyName = args[0].Trim(' ');
        var enemyCommand = table.Find(enemyName);

        yield return enemyCommand.Task.DoCommand(args.Skip(1).ToArray());
        yield return new WaitForSeconds(waitTime);
    }
}
