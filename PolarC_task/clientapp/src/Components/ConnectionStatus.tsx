import React from "react";

interface ConnectionProps {
	isConnected: boolean;
}

const ConnectionStatus: React.FC<ConnectionProps> = ({ isConnected }) => {
	return (
		<div>
			<p>Status: {isConnected ? "Connected" : "Disconnected"}</p>
		</div>
	);
};

export default ConnectionStatus;
