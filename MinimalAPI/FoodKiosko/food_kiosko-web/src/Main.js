// after node.js and yarn are added
// npx create-react-app food_kiosko-web
//
// create this file
// yarn add styled-components


import React, { useState } from "react";
import styled from "styled-components";

const FoodFrame = styled.div`
    border: solid 1px gray;
    padding: 10px;
    margin: 15px 10px;
    border-radius: 5px;
    box-shadow: 0 0 5px grey;
    font-family: Arial;
`;

const Input = styled.input`
    border: solid 1px black;
    padding: 5px;
    border-radius: 3px;
`;

const Title = styled(Input)`
    text-transform: uppercase;
`;

const Save = styled.button`
   width: 100px;
   margin: 10px;
   background: green;
   color: white;
   font-size: 16px;
   padding: 10px;
   border-radius: 5px;
`;

let foods = [{
		id: 1, name: 'SpagguItaly', description: 'Italian fideos'
	},
	{
		id: 2, name: 'Jamburger', description: 'Sweet meat with breads'
	}
];

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
		<FoodFrame>
			<h3>
				<Title onChange={(evt) => update(evt.target.value, 'name', data)} value={data.name} />
			</h3>
			<div>
				<Input onChange={(evt) => update(evt.target.value, 'description', data)} value={data.description} />
			</div>
			{dirty ?
				<div><Save onClick={onSave}>Save</Save></div> : null
			}
		</FoodFrame>
	</React.Fragment>);
}

const Main = () => {
	const data = foods.map(food => <Food food={food} />)

	return (<React.Fragment>
		{data}
	</React.Fragment>)
}

export default Main;
