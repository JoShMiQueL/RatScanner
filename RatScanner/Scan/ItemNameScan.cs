﻿using RatEye;
using RatEye.Processing;
using System;
using System.Linq;

namespace RatScanner.Scan;

public class ItemNameScan : ItemScan {
	private Vector2 _toolTipPosition;

	public ItemNameScan(Inspection inspection, Vector2 toolTipPosition, int duration) {
		RatStash.Item inspectionItem = inspection.Item;
		Item = TarkovDevAPI.GetItems().FirstOrDefault(item => item.Id == inspectionItem.Id) ?? throw new Exception($"Unknown item: {inspection.Item.Id}");
		Confidence = inspection.MarkerConfidence;
		IconPath = inspection.IconPath;
		_toolTipPosition = toolTipPosition;
		DissapearAt = DateTimeOffset.Now.ToUnixTimeMilliseconds() + duration;
	}

	public override Vector2 GetToolTipPosition() {
		return _toolTipPosition;
	}
}
