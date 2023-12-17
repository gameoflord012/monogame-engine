1. Transform component
	Some component may need properties from other component. For example:
		-Sprite renderer may need transform component
		-Godot body need box collider from child component

	General rules or should be no rule at all :)
		-The child behaviour depend on the property of parent
		-There're can be exception ...
		-There may be component constraints

	TODO:
		*Seperate game logic from the core
			*Allow to add multiple game component

		*Vector3 namespace clash between XNA framework and System numeric

		Box2D intergration
			PhysicBody Component
			PhysicSystem

		Child and parent Transform

2. Transform editor