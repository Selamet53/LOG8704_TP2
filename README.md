# Développement d'une Application Mobile AR Simple

Application de réalité augmentée mobile (Android) développée avec Unity pour le cours LOG8704. L'utilisateur scanne des surfaces réelles, y place des animaux, puis peut les déplacer, les faire pivoter, les redimensionner et les animer. L'application inclut aussi une reconnaissance d'images et du contenu dynamique (heure et position GPS).

## Fonctionnalités

- **Placement d'objets** : sept animaux (vache, âne, cheval, cochon, chien, cerf, loup) posés sur les surfaces détectées.
- **Manipulation** : déplacement, rotation, mise à l'échelle et suppression des animaux.
- **Animation au toucher** : chaque animal joue son animation au moment du placement et quand il est touché.
- **Reconnaissance d'images** : lorsque la caméra pointe vers l'image de référence, une vidéo apparaît par-dessus l'image.
- **Contenu dynamique** :
  - **Apparence selon l'heure** : l'apparence des animaux change selon l'heure de la journée. De 6h à 18h, ils ont leurs matériaux d'origine ; la nuit (de 18h à 6h), ils prennent un aspect fantôme grâce à un matériau transparent (*Ghost*). L'heure utilisée est celle du téléphone.
  - **Position GPS** : la latitude et la longitude sont affichées dans un coin de l'écran.

## Scène à build

La scène à inclure dans le build est :

- `Assets/Scenes/SampleScene.unity`

Dans **File > Build Profiles**, vérifier que cette scène est cochée et placée en première position.

## Environnement

- **Unity** : [version, ex. 6000.3.23]
- **Packages principaux** : AR Foundation, ARCore XR Plugin, XR Interaction Toolkit
- **Plateforme cible** : Android

## Appareils de test

L'application a été testée sur 3 appareils Android :

| Appareil | Version d'Android | Résultat |
|---|---|---|
| Samsung A56 | Android 16 | [OK] |
| Samsung Note20 | Android 13 | [OK] avec version API 33 |
| Samsung A34 | Android 15 | [NON] |

Les appareils doivent être compatibles **ARCore** (liste : https://developers.google.com/ar/devices).

## Version d'API Android

Sur la branche `main`, le projet est configuré avec le **niveau d'API 34**.

**Pour un appareil moins récent**, il faut utiliser un niveau d'API **33 ou inférieur** :

1. Ouvrir **Edit > Project Settings > Player > Android > Other Settings**.
2. Modifier **Target API Level** (et **Minimum API Level** si besoin) vers **33 ou moins**.
3. Relancer le build.

## Lancer le projet

1. Cloner le dépôt et l'ouvrir avec la version d'Unity indiquée ci-dessus.
2. Ouvrir la scène `SampleScene`.
3. Sélectionner **Android** dans *Build Profiles*, puis cliquer sur **Switch Platform**.
4. Brancher le téléphone (débogage USB activé) et cliquer sur **Build And Run**.

## Utilisation

1. Bouger lentement le téléphone pour que les surfaces soient détectées.
2. Choisir un animal dans le menu en bas de l'écran.
3. Toucher une surface détectée pour placer l'animal.
4. Glisser l'animal pour le déplacer.
5. Toucher l'animal pour déclencher son animation.

   Pour la reconnaissance d'images:
6. Ouvrir l'application et pointer la caméra vers l'**image de référence**, fournie en **annexe du rapport** (à afficher sur un écran ou à imprimer).
Une vidéo apparaît par-dessus l'image.

**Conseils :** bien éclairer l'image, la garder entière dans le champ de la caméra et éviter les reflets.

## Test dans l'éditeur

Le **simulateur Unity** (Simulated Environment) permet de tester le placement et le déplacement à la souris. Les gestes à deux doigts (rotation, mise à l'échelle) et la qualité réelle du suivi ne peuvent être vérifiés que sur un appareil.

## Limitations connues

- Aucun test sur iOS : la compilation pour iPhone demande un Mac avec Xcode, indisponible dans l'équipe.

## Structure du projet

- `Assets/Models` : modèles FBX des animaux
- `Assets/Prefabs` : prefabs (Rigidbody, XR Grab Interactable, AR Transformer)
- `Assets/Animations` : Animator Controllers
- `Assets/UI` : icônes du menu (sprites)

## Équipe

Noémie Hélias, Lucie Bertho, Emilien de la Brassinne Bonardeaux et Selamet Zamanoglu
