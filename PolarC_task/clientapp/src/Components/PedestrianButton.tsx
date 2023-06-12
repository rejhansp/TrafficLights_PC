import React, { MouseEventHandler } from "react";

interface ButtonProps {
	onClick: MouseEventHandler;
	text: string;
}

const PedestrianButton: React.FC<ButtonProps> = ({ onClick, text }) => {
	return (
		<button
			style={{
				backgroundColor: "#b3d9ff",
				padding: "10px 20px",
				border: "none",
				borderRadius: "5px",
				fontSize: "16px",
				marginTop: "10px",
			}}
			onClick={onClick}
		>
			{text}
		</button>
	);
};

export default PedestrianButton;
