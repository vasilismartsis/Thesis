using JsonCreator.PropertyModels;
using System.Collections.Generic;

namespace JsonCreator
{
    public static class SceneProperties
    {
        public enum PropertyNames
        {
            dimension,
            background,
            modelPath,
            texturesFolderPath,
            materialsFolderPath,
            hasAnimations,
            idleAnimationPath,
            walkingAnimationPath,
            runningAnimationPath,
            jumpingAnimationPath,
            position,
            rotation,
            scale,
            hasCollider,
            colliderType,
            hasPhysics,
            hasGravity,
            isControllable,
            hasMainCamera,
            cameraType,
            health
        }

        public static List<Property> getProjectProperties()
        {
            return new List<Property>
            {
                new ComboProperty
                {
                    name = PropertyNames.dimension,
                    title = "Dimension",
                    description = "The dimension of the game.",
                    options = new List<string>() { "3d", "2d"  },
                    optionValues = new List<string>() { "3D", "2D" },
                    children = new List<PropertyNames>(){ PropertyNames.hasMainCamera }
                },
                new SelectProperty
                {
                    name = PropertyNames.background,
                    title = "The Background Image of the Project",
                    description = "Select the path to the background image of the project.",
                    buttonName = "Choose File",
                    selectType = SelectProperty.SelectType.file,
                    fileFilters = new List<SelectProperty.FileFilter> { SelectProperty.FileFilter.jpg, SelectProperty.FileFilter.jpeg, SelectProperty.FileFilter.png },
                    dimension = Property.Dimension._2d,
                    optional = true
                }
            };
        }

        public static List<Property> getModelProperties()
        {
            return new List<Property>
            {
                new SelectProperty
                {
                    name = PropertyNames.modelPath,
                    title = "The 3D Model",
                    description = "Select the path to the 3D model. (Only .fbx are supported at the time)",
                    buttonName = "Choose File",
                    selectType = SelectProperty.SelectType.file,
                    fileFilters = new List<SelectProperty.FileFilter> { SelectProperty.FileFilter.fbx },
                    dimension = Property.Dimension._3d
                },
                new SelectProperty
                {
                    name = PropertyNames.modelPath,
                    title = "The 2D Model",
                    description = "Select the path to the 2D model.",
                    buttonName = "Choose File",
                    selectType = SelectProperty.SelectType.file,
                    fileFilters = new List<SelectProperty.FileFilter> { SelectProperty.FileFilter.jpg, SelectProperty.FileFilter.jpeg, SelectProperty.FileFilter.png },
                    dimension = Property.Dimension._2d
                },
                new SelectProperty
                {
                    name = PropertyNames.texturesFolderPath,
                    title = "The Textures Folder",
                    description = "Select the path to the textures folder.",
                    buttonName = "Choose Folder",
                    selectType = SelectProperty.SelectType.folder,
                    dimension = Property.Dimension._3d
                },
                new SelectProperty
                {
                    name = PropertyNames.materialsFolderPath,
                    title = "The Materials Folder*",
                    description = "Select the path to the materials folder, if it exists. (Optional)",
                    buttonName = "Choose Folder",
                    selectType = SelectProperty.SelectType.folder,
                    dimension = Property.Dimension._3d,
                    optional = true
                },
                new ComboProperty
                {
                    name = PropertyNames.hasAnimations,
                    title = "Has Animations",
                    description = "Set to true if the object has gravity.",
                    options = new List<string>() { "true", "false" },
                    optionValues = new List<string>() { "True", "False" },
                    children = new List<PropertyNames>() { PropertyNames.idleAnimationPath, PropertyNames.walkingAnimationPath, PropertyNames.runningAnimationPath, PropertyNames.jumpingAnimationPath },
                    dimension = Property.Dimension.both
                },
                new SelectProperty
                {
                    name = PropertyNames.idleAnimationPath,
                    title = "The Idle Animation of the Object*",
                    description = "Select the path to the Idle animation of the object.",
                    buttonName = "Choose File",
                    selectType = SelectProperty.SelectType.file,
                    fileFilters = new List<SelectProperty.FileFilter> { SelectProperty.FileFilter.anim, SelectProperty.FileFilter.fbx },
                    dimension = Property.Dimension._3d,
                    optional = true
                },
                new SelectProperty
                {
                    name = PropertyNames.idleAnimationPath,
                    title = "The Idle Animation of the Object*",
                    description = "Select the path to the folder that contains the images for the Idle animation of the object.",
                    buttonName = "Choose Folder",
                    selectType = SelectProperty.SelectType.folder,
                    dimension = Property.Dimension._2d,
                    optional = true
                },
                new SelectProperty
                {
                    name = PropertyNames.walkingAnimationPath,
                    title = "The Walking Animation of the Object*",
                    description = "Select the path to the Walking animation of the object.",
                    buttonName = "Choose File",
                    selectType = SelectProperty.SelectType.file,
                    fileFilters = new List<SelectProperty.FileFilter> { SelectProperty.FileFilter.anim, SelectProperty.FileFilter.fbx },
                    dimension = Property.Dimension._3d,
                    optional = true
                },
                new SelectProperty
                {
                    name = PropertyNames.walkingAnimationPath,
                    title = "The Walking Animation of the Object*",
                    description = "Select the path to the folder that contains the images for the Walking animation of the object.",
                    buttonName = "Choose Folder",
                    selectType = SelectProperty.SelectType.folder,
                    dimension = Property.Dimension._2d,
                    optional = true
                },
                new SelectProperty
                {
                    name = PropertyNames.runningAnimationPath,
                    title = "The Running Animation of the Object*",
                    description = "Select the path to the Running animation of the object.",
                    buttonName = "Choose File",
                    selectType = SelectProperty.SelectType.file,
                    fileFilters = new List<SelectProperty.FileFilter> { SelectProperty.FileFilter.anim, SelectProperty.FileFilter.fbx },
                    dimension = Property.Dimension._3d,
                    optional = true
                },
                new SelectProperty
                {
                    name = PropertyNames.runningAnimationPath,
                    title = "The Running Animation of the Object*",
                    description = "Select the path to the folder that contains the images for the Running animation of the object.",
                    buttonName = "Choose Folder",
                    selectType = SelectProperty.SelectType.folder,
                    dimension = Property.Dimension._2d,
                    optional = true
                },
                new SelectProperty
                {
                    name = PropertyNames.jumpingAnimationPath,
                    title = "The Jumping Animation of the Object*",
                    description = "Select the path to the Jumping animation of the object.",
                    buttonName = "Choose File",
                    selectType = SelectProperty.SelectType.file,
                    fileFilters = new List<SelectProperty.FileFilter> { SelectProperty.FileFilter.anim, SelectProperty.FileFilter.fbx },
                    dimension = Property.Dimension._3d,
                    optional = true
                },
                new SelectProperty
                {
                    name = PropertyNames.jumpingAnimationPath,
                    title = "The Jumping Animation of the Object*",
                    description = "Select the path to the folder that contains the images for the Jumping animation of the object.",
                    buttonName = "Choose Folder",
                    selectType = SelectProperty.SelectType.folder,
                    dimension = Property.Dimension._2d,
                    optional = true
                },
                new VectorProperty
                {
                    name = PropertyNames.position,
                    title = "Position",
                    description = "The position of the Object.",
                    values = new VectorProperty.Values(0,0,0),
                    dimension = Property.Dimension.both
                },
                new VectorProperty
                {
                    name = PropertyNames.rotation,
                    title = "Rotation",
                    description = "The rotation of the Object.",
                    values = new VectorProperty.Values(0,0,0),
                    dimension = Property.Dimension.both
                },
                new VectorProperty
                {
                    name = PropertyNames.scale,
                    title = "Scale",
                    description = "The scale of the Object.",
                    values = new VectorProperty.Values(1,1,1),
                    dimension = Property.Dimension.both
                },
                new ComboProperty
                {
                    name = PropertyNames.hasCollider,
                    title = "Has Collider",
                    description = "If set to true, this object will be able to handle collisions with other objects",
                    options = new List<string>() { "true", "false"  },
                    optionValues = new List<string>() { "True", "False" },
                    children = new List<PropertyNames>() { PropertyNames.colliderType },
                    dimension = Property.Dimension.both
                },
                new ComboProperty
                {
                    name = PropertyNames.colliderType,
                    title = "Collider Type",
                    description = "The collider type of the object.",
                    options = new List<string>() { "meshCollider", "boxCollider", "capsuleCollider", "sphereCollider", "terrainCollider"  },
                    optionValues = new List<string>() { "Auto Detect Collider", "Box Collider", "Capsule Collider",  "Sphere Collider", "Terrain Collider" },
                    dimension = Property.Dimension._3d
                },
                new ComboProperty
                {
                    name = PropertyNames.colliderType,
                    title = "Collider Type",
                    description = "The collider type of the object.",
                    options = new List<string>() { "polygonCollider2D", "boxCollider2D", "capsuleCollider2D", "circleCollider2D", "compositeCollider2D", "edgeCollider2D"  },
                    optionValues = new List<string>() { "Auto Detect Collider 2D", "Box Collider 2D", "Capsule Collider 2D", "Circle Collider 2D", "Composite Collider 2D", "Edge Collider 2D" },
                    dimension = Property.Dimension._2d
                },
                new ComboProperty
                {
                    name = PropertyNames.hasPhysics,
                    title = "Has Physics",
                    description = "Set to true if the object has physics.",
                    options = new List<string>() { "true", "false"  },
                    optionValues = new List<string>() { "True", "False" },
                    dimension = Property.Dimension.both,
                    children = new List<PropertyNames>() { PropertyNames.hasGravity }
                },
                new ComboProperty
                {
                    name = PropertyNames.hasGravity,
                    title = "Has Gravity",
                    description = "Set to true if the object has gravity.",
                    options = new List<string>() { "true", "false"  },
                    optionValues = new List<string>() { "True", "False" },
                    dimension = Property.Dimension.both
                },
                new ComboProperty
                {
                    name = PropertyNames.isControllable,
                    title = "Is Controllable",
                    description = "Set to true if the object is suposed to be controlled by the player. (note: Only one character can be controllable.)",
                    options = new List<string>() { "true", "false"  },
                    optionValues = new List<string>() { "True", "False" },
                    dimension = Property.Dimension.both,
                    unique = true
                },
                new ComboProperty
                {
                    name = PropertyNames.hasMainCamera,
                    title = "Has Main Camera",
                    description = "Set to true if the object has the main camera attached to it.",
                    options = new List<string>() { "true", "false"  },
                    optionValues = new List<string>() { "True", "False" },
                    dimension = Property.Dimension.both,
                    children = new List<PropertyNames>() { PropertyNames.cameraType },
                    unique = true
                },
                new ComboProperty
                {
                    name = PropertyNames.cameraType,
                    title = "Camera Type",
                    description = "The type of the Camera.",
                    options = new List<string>() { "thirdPerson", "firstPerson"  },
                    optionValues = new List<string>() { "Third Person", "First Person" },
                    dimension = Property.Dimension._3d,
                },
                new TextProperty
                {
                    name = PropertyNames.health,
                    title = "Health",
                    description = "The health of the object.",
                    valueType = TextProperty.ValueType.numeric,
                    value = "10"
                }
            };
        }
    }
}
