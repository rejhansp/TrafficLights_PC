export interface TrafficLightDto {
	id: number;
	duration: number;
	color: string;
	isAfterGreen: boolean;
	hasPedestrianInvokedRed: boolean;
}
