---@class BaseView
module("BaseView", package.seeall)
function new()
    local obj = {}
    setmetatable(obj, {__index = BaseView})
    obj:init()
    return obj
end
function init()
    self.name = "BaseView"
    self.gameObject = nil
    self.transform = nil
end

function onAfterOpen()
    
end