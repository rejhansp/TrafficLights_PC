import React, { useEffect, useState } from "react";
import { HubConnectionBuilder, HubConnection } from "@microsoft/signalr";
import TrafficLight from "./Components/TrafficLight";
import PedestrianButton from "./Components/PedestrianButton";
import ConnectionStatus from "./Components/ConnectionStatus";

interface TrafficLightDto {
	id: number;
	duration: number;
	color: string;
	isAfterGreen: boolean;
	hasPedestrianInvokedRed: boolean;
}

const TrafficPage = () => {
	const [isStopped, setIsStopped] = useState(true);
	const [isConnected, setIsConnected] = useState(false);
	const [trafficLightData, setTrafficLightData] = useState<TrafficLightDto | null>(null);

	const [connection, setConnection] = useState<HubConnection>();

	useEffect(() => {
		const newConnection = new HubConnectionBuilder().withUrl("https://localhost:7173/hubs/chat").withAutomaticReconnect().build();

		setConnection(newConnection);
	}, []);

	useEffect(() => {
		if (connection) {
			connection
				.start()
				.then((result) => {
					setIsConnected(true);
					connection.on("ReceiveStatusAsync", (state) => {
						setTrafficLightData(state);
					});
				})
				.catch((e) => {
					console.log("Connection failed: ", e);
					setIsConnected(false);
				});
		}
	}, [connection]);

	console.log(isStopped);

	const handleStopClick = () => {
		setIsStopped(true);
	};

	return (
		<div>
			<TrafficLight trafficLightData={trafficLightData} />
			<PedestrianButton onClick={handleStopClick} text="Stop" />
			<ConnectionStatus isConnected={isConnected} />
		</div>
	);
};

export default TrafficPage;
