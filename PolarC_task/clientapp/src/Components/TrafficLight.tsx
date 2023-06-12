import React from "react";
import { TrafficLightDto } from "../Models/ITrafficLight";

interface IProps {
	trafficLightData: TrafficLightDto | null;
}

const TrafficLight: React.FC<IProps> = ({ trafficLightData }) => {
	let yellowAndRed = trafficLightData?.isAfterGreen && trafficLightData.id === 2;

	return (
		<div style={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
			<div
				style={{
					backgroundColor: trafficLightData?.id === 1 || yellowAndRed ? "#b22d1b" : "#ffffff",
					width: "100px",
					height: "100px",
					borderRadius: "50%",
					position: "relative",
					margin: "5px",
				}}
			>
				{(trafficLightData?.id === 1 || yellowAndRed) && (
					<div
						style={{
							position: "absolute",
							top: "50%",
							left: "50%",
							transform: "translate(-50%, -50%)",
							fontSize: "24px",
							color: "white",
						}}
					>
						{trafficLightData?.duration}
					</div>
				)}
			</div>

			<div
				style={{
					backgroundColor: trafficLightData?.id === 2 ? "#ecc200" : "#ffffff",
					width: "100px",
					height: "100px",
					borderRadius: "50%",
					margin: "5px",
				}}
			>
				{trafficLightData?.id === 2 && (
					<div
						style={{
							position: "absolute",
							top: "50%",
							left: "50%",
							transform: "translate(-50%, -50%)",
							fontSize: "24px",
							color: "white",
						}}
					>
						{trafficLightData?.duration}
					</div>
				)}
			</div>

			<div
				style={{
					backgroundColor: trafficLightData?.id === 3 ? "#3f7e3f" : "#ffffff",
					width: "100px",
					height: "100px",
					borderRadius: "50%",
					margin: "5px",
				}}
			>
				{trafficLightData?.id === 3 && (
					<div
						style={{
							position: "absolute",
							top: "55%",
							left: "50%",
							transform: "translate(-50%, -50%)",
							fontSize: "24px",
							color: "white",
						}}
					>
						{trafficLightData?.duration}
					</div>
				)}
			</div>
		</div>
	);
};

export default TrafficLight;
