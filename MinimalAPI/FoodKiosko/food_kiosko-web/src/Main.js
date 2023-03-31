// after node.js and yarn are added
// npx create-react-app food_kiosko-web
//
// create this file


import React, { useState } from "react";

let foods = [{
		id: 1, name: 'SpagguItaly', description: 'Italian fideos'
	},
	{
		id: 2, name: 'Jamburger', description: 'Sweet meat with breads'
	}
}];

const Food = ({ food }) => {
	const [data, setData] = useState(food);
	const [dirty, setDirty] = useState(false);

	function update(value, fieldName, obj) {
		setData({ ...obj, [fieldName]: value });
		setDirty(true);
	}

	function onSave() {
		setDirty(false);
		//make rest call
	}

	return (<React.Fragment>
		<div>
			<h3>
				<input onChange={(evt) => update(evt.target.value, 'name', data)} value={data.name} />
			</h3>
		</div>
		<div>
			<input onChange={(evt) => update(evt.target.value, 'description', data)} value={data.description} />
		</div>
		{dirty ?
			<div><button onClick={onSave}>Save</button></div> : null
		}
	</React.Fragment>);
}

const Main = () => {
	const data = foods.map(food => <Food food={food} />)

	return (<React.Fragment>
		{data}
	</React.Fragment>)
}

export default Main;
