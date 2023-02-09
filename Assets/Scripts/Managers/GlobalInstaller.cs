using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    public AudioManager _audioManager;
    public Player player;
    public HelixManager _helixManager;
    public GameManager _gameManager;
    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle();
        Container.Bind<Player>().FromInstance(player).AsSingle();
        Container.Bind<HelixManager>().FromInstance(_helixManager).AsSingle();
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
    }
}