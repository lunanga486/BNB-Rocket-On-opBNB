// SPDX-License-Identifier: MIT
pragma solidity ^0.8.17;

contract BNBRocketGame {
    mapping(address => bool) private gamePass;
    mapping(address => uint256) private gold;

    // Events
    event gamePassGiven(address indexed player);
    event goldClaimed(address indexed player, uint256 newCount);

    function hasGamePass(address player) external view returns (bool) {
        return gamePass[player];
    }

    function claimGamePass(address player) external {
        gamePass[player] = true;
        emit gamePassGiven(player);
    }

    function getGold(address player) external view returns (uint256) {
        return gold[player];
    }

    function giveGold(address player) external {
        gold[player] += 1;
        emit goldClaimed(player, gold[player]);
    }
}
